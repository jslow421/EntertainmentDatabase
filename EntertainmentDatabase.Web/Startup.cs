using System;
using System.Net;
using EntertainmentDatabase.Database.AppAccess;
using EntertainmentDatabase.Database.AppAccess.Repository;
using EntertainmentDatabase.Database.AppAccess.Repository.Interfaces;
using EntertainmentDatabase.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using VueCliMiddleware;


namespace EntertainmentDatabase.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Connection strings
            var userConnectionString = Configuration.GetConnectionString("UserDatabase");
            var movieConnectionString = Configuration.GetConnectionString("MovieDatabase");

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client_app/dist";
            });

            // Services
            services.AddSingleton<IDbConnectionFactory>(s => new DbConnectionFactory(movieConnectionString));
            services.AddSingleton<IUpcDataManager, UpcDataManager>();
            services.AddSingleton<IUserService, UserService>();
            
            // Repositories
            services.AddSingleton<IMovieReadDataAccess, MovieReadDataAccess>();
            services.AddSingleton<IMovieWriteDataAccess, MovieWriteDataAccess>();

            // Auth
            // Reference: https://joonasw.net/view/aspnet-core-2-azure-ad-authentication
            services.AddAuthentication(options =>
                {
                    // Cookie scheme
                    // 1) Sign the user in (i.e. creating the authentication cookie and returning it to the browser)
                    options.DefaultSignInScheme = "Entertainment-Database";

                    // 2) Authentication in requests and creating user principals from the cookie.
                    options.DefaultAuthenticateScheme = "Entertainment-Database";
                    
                    // Open ID Connect Scheme
                    // 1) Respond to challenges from [Authorize] or ChallengeResult returned from controllers by sending the user to authenticate against the specified identity provider.
                    options.DefaultChallengeScheme = "Entertainment-Database";
                })
                .AddCookie("Entertainment-Database", options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.Path = "/";
                    options.Cookie.Name = "luda-auth";
                    // We'll be handling auth errors on the web app, so return codes rather than redirects.
                    options.Events.OnRedirectToLogin = async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await context.Response.WriteAsync("Some custom error message if required");
                    };
                    // Reference: https://www.owasp.org/index.php/SameSite
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = new TimeSpan(0, 0, 0, 10);
                    options.Cookie.Expiration = TimeSpan.FromDays(1);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client_app";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
        }
    }
}
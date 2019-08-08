using System;
using System.Net.Http;
using System.Threading.Tasks;
using EntertainmentDatabase.Core.Dto;
using Newtonsoft.Json;

namespace EntertainmentDatabase.Services
{
    public class UpcDataManager : IUpcDataManager
    {
        public async Task<UpcItemDbDto> GetItemDetailsFromExternalApi(string upc)
        {
            var response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                try
                {
                    // todo move api url to settings
                    response = await client.GetAsync($"https://api.upcitemdb.com/prod/trial/lookup?upc={upc}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // todo Consider other options to handle this without multiple returns
            if (response == null) return new UpcItemDbDto
            {
                Message = "Response was null",
                Code = "NOT_FOUND"
            };
            
            var data = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<UpcItemDbDto>(data);
            
            return item;
        }
    }
}
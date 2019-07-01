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
                    response = await client.GetAsync($"https://api.upcitemdb.com/prod/trial/lookup?upc={upc}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // I'm not wild about two returns. Consider other options
            // Just faking this for now - need to actually figure out why it would be null
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
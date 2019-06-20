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

            if (response == null) return new UpcItemDbDto();
            
            var data = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<UpcItemDbDto>(data);
            
            return item;
        }
    }
}
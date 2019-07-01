using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EntertainmentDatabase.Core.Dto
{
    public class UpcItemDbDto
    {
        [JsonProperty("items")]
        public List<UpcItemDbDetailsDto> Items { get; set; }
        public string Code { get; set; }
        public int Total { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EntertainmentDatabase.Core.Dto
{
    public class UpcItemDbDto
    {
        [JsonProperty("items")]
        public List<UpcItemDbDetailsDto> Items { get; set; }
    }
}
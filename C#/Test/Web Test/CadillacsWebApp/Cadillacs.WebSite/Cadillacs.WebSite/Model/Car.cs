using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cadillacs.WebSite.Model
{
    public class Car
    {
        [JsonPropertyName("Model")]
        public string Model { get; set; }
        [JsonPropertyName("maker")]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        [JsonPropertyName("moto")]
        public string Moto { get; set; }
        [JsonPropertyName("class")]
        public string Class { get; set; }
        public int[] Ratings { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Car>(this);
       
    }
}

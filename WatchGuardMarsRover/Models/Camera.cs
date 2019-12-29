using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchGuardMarsRover.Models
{
    [JsonObject("camera")]
    public class Camera
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("rover_id")]
        public int rover_id { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }
}

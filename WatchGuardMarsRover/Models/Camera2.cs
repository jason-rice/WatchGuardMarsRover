using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchGuardMarsRover.Models
{
    [JsonObject("cameras")]
    public class Camera2
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchGuardMarsRover.Models
{
    public class MarsRoverImage
    {
        [JsonProperty("photos")]
        public List<Photo> PhotoList { get; set; }
        //public int sol { get; set; }
        //public string camera { get; set; }
        //public string img_src { get; set; }
        //public string earth_date { get; set; }
        //public string rover { get; set; }
    }
}

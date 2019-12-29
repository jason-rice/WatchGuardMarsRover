using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WatchGuardMarsRover.Helper
{
    public class MarsRoverApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.nasa.gov/mars-photos/");
            return client;
        }
    }
}

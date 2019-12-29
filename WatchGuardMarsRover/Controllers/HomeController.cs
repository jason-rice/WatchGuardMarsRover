using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WatchGuardMarsRover.Helper;
using WatchGuardMarsRover.Models;
//using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace WatchGuardMarsRover.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MarsRoverApi _api = new MarsRoverApi();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetImagesByDate(string dateChosen)
        {
            if(dateChosen != null)
            {
                try
                {
                    MarsRoverImage marsRoverImage = new MarsRoverImage();
                    HttpClient client = _api.Initial();
                    //dateChosen = "2015-6-3";
                    HttpResponseMessage responseMessage = await client.GetAsync("api/v1/rovers/curiosity/photos?earth_date=" + dateChosen + "&api_key=gVnoxQADOqBDAVopaZlfEhYtL7gNSxrXrQDruJDv");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var resultString = responseMessage.Content.ReadAsStringAsync().Result;
                        marsRoverImage = JsonConvert.DeserializeObject<MarsRoverImage>(resultString);

                        foreach (var item in marsRoverImage.PhotoList)
                        {
                            using (WebClient currentClient = new WebClient())
                            {
                                currentClient.DownloadFile(new Uri(item.img_src), @"C:\Users\jason\source\repos\WatchGuardMarsRover\WatchGuardMarsRover\wwwroot\Images\NasaPic" + item.id + ".png");
                            }
                        }
                    }
                    return Json("success");
                }
                catch
                {
                    return Json("fail");
                }
            }
            else
            {
                return Json("fail");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

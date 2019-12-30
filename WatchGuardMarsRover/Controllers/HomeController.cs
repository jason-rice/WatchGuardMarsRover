using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WatchGuardMarsRover.Helper;
using WatchGuardMarsRover.Models;
using Microsoft.AspNetCore.Http;

namespace WatchGuardMarsRover.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MarsRoverApi _api = new MarsRoverApi();
        protected Repository _repository { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = new Repository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetImagesByDate(string dateChosen)
        {
            if(dateChosen != null)
            {
                List<DisplayImages> displayImagesList = new List<DisplayImages>();
                await _repository.GetNasaImagesByDate(dateChosen, displayImagesList);
                return Json(displayImagesList);
            }
            else
            {
                List<DisplayImages> displayImagesList = new List<DisplayImages>();
                await _repository.GetNasaImagesByDateArray(displayImagesList);
                return Json(displayImagesList);
            }
        }

        public async Task<IActionResult> GetFirstFifteenImagesByDate(string dateChosen)
        {
            if (dateChosen != null)
            {
                List<DisplayImages> displayImagesList = new List<DisplayImages>();
                await _repository.GetFirstFifteenNasaImagesByDate(dateChosen, displayImagesList);
                return Json(displayImagesList);
            }
            else
            {
                List<DisplayImages> displayImagesList = new List<DisplayImages>();
                await _repository.GetFirstFifteenNasaImagesByDateArray(displayImagesList);
                return Json(displayImagesList);
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

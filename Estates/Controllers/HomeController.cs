using Estates.Helpers;
using Estates.Interfaces;
using Estates.Models;
using Estates.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace Estates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlatRepository _flatRepository;

        public HomeController(ILogger<HomeController> logger, IFlatRepository flatRepository)
        {
            _logger = logger;
            _flatRepository = flatRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeViewModel = new HomeViewModel();
            try
            {
                string url = "http://ipinfo.io/178.207.179.218?token=105b234e6a0544";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                homeViewModel.City = ipInfo.City;
                homeViewModel.State = ipInfo.Region;
                if(homeViewModel.City != null)
                {
                    homeViewModel.Flats = await _flatRepository.GetFlatByCity(homeViewModel.City);
                }
                else
                {
                    homeViewModel.Flats = null;
                }
                return View(homeViewModel);
            }
            catch(Exception ex)
            {
                homeViewModel.Flats = null;
            }

            return View(homeViewModel);
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
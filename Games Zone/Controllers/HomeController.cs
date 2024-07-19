using Games_Zone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Games_Zone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesService _gamesService;

        public HomeController(ILogger<HomeController> logger, IGamesService gamesService)
        {
            _logger = logger;
            _gamesService = gamesService;
        }
        public async Task<IActionResult> Index(string? Name ,int flag)
        {
            dynamic games;

            games = await _gamesService.GetAllAsync();

            if (flag >0)
                games = await _gamesService.GetTopRatedAsync();

            

            if(Name is not null)
            {
                games=_gamesService.GetByNameAsync(Name);
            }

            return View(games);
        }
        //public async Task<IActionResult> topRated()
        //{
        //    var topRatedGames =await _gamesService.GetTopRatedAsync();

        //    ViewBag.Message = "Top rated games";

        //    return View(topRatedGames);
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
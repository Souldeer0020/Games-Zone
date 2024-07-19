using Microsoft.AspNetCore.Mvc;

namespace Games_Zone.Controllers
{
    [Authorize]
    public class userController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Games_Zone.Controllers
{
    [Authorize(Roles ="admin")]
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

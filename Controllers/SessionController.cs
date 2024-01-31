using Microsoft.AspNetCore.Mvc;

namespace PassingDataInApplicationUsingSession.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Username", "Sardar Mudassar Ali Khan");
            return View();
        }

        public IActionResult About()
        {
            string username = HttpContext.Session.GetString("Username");
            ViewData["Username"] = username;
            return View();
        }
    }
}

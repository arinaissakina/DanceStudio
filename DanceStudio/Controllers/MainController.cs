using Microsoft.AspNetCore.Mvc;

namespace DanceStudio.Controllers
{
    public class MainController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
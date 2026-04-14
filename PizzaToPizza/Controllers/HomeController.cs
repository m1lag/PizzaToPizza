using Microsoft.AspNetCore.Mvc;

namespace PizzaToPizza.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

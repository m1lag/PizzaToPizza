using Microsoft.AspNetCore.Mvc;

namespace PizzaToPizza.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Информация о проекте PizzaToPizza.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Свяжитесь с нами.";
            return View();
        }
    }
}

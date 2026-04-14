using Microsoft.AspNetCore.Mvc;

namespace PizzaToPizza.Controllers
{
    public class HomeController : Controller
    {
        // Главная страница
        public IActionResult Index()
        {
            return View();
        }

        // Страница "О нас"
        public IActionResult About()
        {
            ViewData["Message"] = "Информация о проекте PizzaToPizza.";
            return View();
        }

        // Страница "Контакты"
        public IActionResult Contact()
        {
            ViewData["Message"] = "Свяжитесь с нами.";
            return View();
        }
    }
}

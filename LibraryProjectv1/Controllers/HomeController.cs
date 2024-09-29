using Microsoft.AspNetCore.Mvc;

namespace LibraryProjectv1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

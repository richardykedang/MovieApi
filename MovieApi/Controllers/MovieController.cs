using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

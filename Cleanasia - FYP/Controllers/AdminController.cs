using Microsoft.AspNetCore.Mvc;

namespace Cleanasia.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

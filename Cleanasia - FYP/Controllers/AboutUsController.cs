using Microsoft.AspNetCore.Mvc;

namespace Cleanasia.Controllers
{
	public class AboutUsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

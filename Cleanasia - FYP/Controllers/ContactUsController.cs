using Cleanasia.Data;
using Cleanasia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cleanasia.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly CleanasiaContext _context;

		public ContactUsController( CleanasiaContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(ContactUsModel contactUs)
		{
			_context.Add(contactUs);
			_context.SaveChangesAsync();
			return View();
		}
	}
}

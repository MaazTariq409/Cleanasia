using Cleanasia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCuisine.ViewModels;
using System.Threading.Tasks;

namespace Cleanasia.Controllers
{
	public class AdminController : Controller
	{
		private readonly CleanasiaContext _context;

		public AdminController(CleanasiaContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Administration()
		{
			ProductViewModel productViewModel = new ProductViewModel();

			productViewModel.categories = await _context.category.ToListAsync();
			productViewModel.services = await _context.Service.ToListAsync();

			return View(productViewModel);
		}
	}
}
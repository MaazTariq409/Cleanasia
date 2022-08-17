using Cleanasia.Data;
using Cleanasia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult AdminDashboard()
        {
            return View();
        }


        public async Task<IActionResult> Administration()
        {
            ServicesViewModel productViewModel = new ServicesViewModel();

            productViewModel.categories = await _context.category.ToListAsync();
            productViewModel.services = await _context.Service.ToListAsync();

            return View(productViewModel);
        }
    }
}

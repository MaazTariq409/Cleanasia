using Cleanasia.Data;
using Cleanasia.Models;
using Cleanasia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cleanasia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CleanasiaContext _context;

        public HomeController(ILogger<HomeController> logger, CleanasiaContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.category.ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {
            ServicesViewModel productViewModel = new ServicesViewModel();

            productViewModel.categories = await _context.category.ToListAsync();
            productViewModel.services = await _context.Service.ToListAsync();

            return View(productViewModel);
        }

        public async Task<IActionResult> Services()
        {
            var CleanasiaContext = _context.Service.Include(s => s.ServiceCategory);
            return View(await CleanasiaContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult ContactUs(ContactUsModel contactUs)
        {
            _context.Add(contactUs);
            _context.SaveChangesAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Cleanasia.Data;
using Cleanasia.Models;
using Cleanasia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
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
            ServicesViewModel serviceViewModel = new ServicesViewModel();

            serviceViewModel.categories = await _context.category.ToListAsync();
            serviceViewModel.services = await _context.Service.ToListAsync();

            return View(serviceViewModel);
        }

        public async Task<IActionResult> OrderList()
        {
            return View(await _context.bookingService.ToListAsync());
        }

        public async Task<IActionResult> Services(int? id)
        {
            if (id == null)
            {
                ServiceListDetailViewModel serviceViewModel = new ServiceListDetailViewModel();
                var AllServices = await _context.Service.Include(p => p.ServiceCategory).ToListAsync();
                serviceViewModel.Products = AllServices;
                return View(serviceViewModel);
            }
            ServiceListDetailViewModel ServiceViewModel = new ServiceListDetailViewModel();
            var ServiceModel = await _context.Service
                .Include(p => p.ServiceCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            ServiceViewModel.Description = ServiceModel.Discription;
            ServiceViewModel.Picture = ServiceModel.picture;
            ServiceViewModel.Name = ServiceModel.Name;
            ServiceViewModel.Price = ServiceModel.price;
            ServiceViewModel.ProductCategoryID = ServiceModel.ProductCategoryID;

            var AllProducts = await _context.Service.Where(p => p.ID==id).ToListAsync();
            ServiceViewModel.Products = AllProducts;

            return View(ServiceViewModel);
        }

        //public async Task<IActionResult> Services(int? id)
        //{

        //    ServiceListDetailViewModel ServiceViewModel = new ServiceListDetailViewModel();
        //    var ServiceModel = await _context.Service
        //        .Include(p => p.ServiceCategory)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    ServiceViewModel.Id = ServiceModel.ID;

        //    ServiceViewModel.Description = ServiceModel.Discription;
        //    ServiceViewModel.Picture = ServiceModel.picture;
        //    ServiceViewModel.Name = ServiceModel.Name;
        //    ServiceViewModel.ProductCategoryID = ServiceModel.ProductCategoryID;
        //    ServiceViewModel.Quantity = 1;

        //    var AllProducts = await _context.Service.Include(p => p.ServiceCategory).ToListAsync();
        //    ServiceViewModel.Products = AllProducts;

        //    return View(ServiceViewModel);
        //}

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

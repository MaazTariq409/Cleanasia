using Cleanasia.Data;
using Cleanasia.Models;
using Cleanasia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Cleanasia.Controllers
{
    [Authorize]
    public class BookingServiceController : Controller
    {
        private readonly CleanasiaContext _context;

        public BookingServiceController(CleanasiaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.bookingService.ToList());
        }
        public IActionResult Create()
        {
            BookingViewModel productViewModel = new BookingViewModel();
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                bookingServiceModel obj = new bookingServiceModel() { Name = booking.Name, Email = booking.Email, Phone = booking.Phone, Address = booking.Address, StartingDateTime = booking.StartingDateTime, Hours = booking.Hours};
                _context.bookingService.Add(obj);
                await _context.SaveChangesAsync();
            }
            return View(booking);
        }

        //public async Task<IActionResult> ServiceDetails(int? id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ServiceModel = await _context.Service
        //        .Include(p => p.ServiceCategory)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (ServiceModel == null)
        //    {
        //        return NotFound();
        //    }
        //    ServiceListDetailViewModel ServiceViewModel = new ServiceListDetailViewModel();
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
        //public async Task<IActionResult> ProductDetail(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var serviceModel = await _context.Service
        //        .Include(p => p.ServiceCategory)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (serviceModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(serviceModel);
        //}

        public IActionResult CheckOut()
        {
            return View();
        }
    }
}

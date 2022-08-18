using Cleanasia.Data;
using Cleanasia.Models;
using Cleanasia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Cleanasia.Controllers
{
    public class BookingServiceController : Controller
    {
        private readonly CleanasiaContext _context;

        public BookingServiceController(CleanasiaContext context)
        {
            _context = context;
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
    }
}

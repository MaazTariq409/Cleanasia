using Cleanasia.Data;
using Cleanasia.Models;
using Cleanasia.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
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
        public async Task<IActionResult> Create(int? id)
        {
            
            ServiceListDetailViewModel ServiceViewModel = new ServiceListDetailViewModel();
            var ServiceModel =await _context.Service
                .Include(p => p.ServiceCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            ServiceViewModel.Id = ServiceModel.ID;

            ServiceViewModel.Description = ServiceModel.Discription;
            ServiceViewModel.Picture = ServiceModel.picture;
            ServiceViewModel.Name = ServiceModel.Name;
            ServiceViewModel.Price = ServiceModel.price;
            ServiceViewModel.ProductCategoryID = ServiceModel.ProductCategoryID;

            var AllProducts = await _context.Service.Include(p => p.ServiceCategory).ToListAsync();
            ServiceViewModel.Products = AllProducts;

            return View(ServiceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceListDetailViewModel booking)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        //Set Key Name
                        var PictureName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        //Get url To Save
                        string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploadsPic", PictureName);

                        using (var stream = new FileStream(SavePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            booking.picture = PictureName;
                        }
                    }
                }

                bookingServiceModel obj = new bookingServiceModel() { Name = booking.Name, Email = booking.Email, Phone = booking.Phone, Address = booking.Address, StartingDateTime = booking.StartingDateTime, Hours = booking.Hours, Receipt = booking.Receipt, picture= booking.picture};
                _context.bookingService.Add(obj);
                await _context.SaveChangesAsync();
                ViewBag.Message = "The Booking Confirmation message will be sent via Email";
            }
            return View(booking);
            //return RedirectToAction("allServices", "Home");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.category
                .FirstOrDefaultAsync(m => m.ID == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryModel = await _context.category.FindAsync(id);
            _context.category.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelExists(int id)
        {
            return _context.category.Any(e => e.ID == id);
        }
    }
}

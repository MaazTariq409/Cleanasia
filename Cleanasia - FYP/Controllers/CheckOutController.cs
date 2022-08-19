using Cleanasia.Data;
using Cleanasia.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Cleanasia.Controllers
{
	public class CheckOutController : Controller
	{
		private readonly CleanasiaContext _context;

		public CheckOutController(CleanasiaContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CheckOut()
		{
			return View();
		}

		[HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut([Bind("ID,Receipt,picture")] CheckOutModel checkOut)
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
                            checkOut.picture = PictureName;
                        }
                    }
                }

                _context.Add(checkOut);
                await _context.SaveChangesAsync();
                ViewBag.Message = "The Booking Confirmation message will be sent via Email";
            }
            return View(checkOut);
        }
    }
}

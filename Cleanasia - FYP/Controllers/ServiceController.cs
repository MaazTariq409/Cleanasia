using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Cleanasia.Data;
using Cleanasia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cleanasia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly CleanasiaContext _context;

        public ServiceController(CleanasiaContext context)
        {
            _context = context;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            var CleanasiaContext = _context.Service.Include(s => s.ProductCategory);
            return View(await CleanasiaContext.ToListAsync());
        }

        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Service
                .Include(s => s.ProductCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryID"] = new SelectList(_context.category, "ID", "ID");
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductCategoryID,Name,Discription,PhoneNumber,picture")] ServiceModel serviceModel)
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
                            serviceModel.picture = PictureName;
                        }
                    }
                }

                _context.Add(serviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryID"] = new SelectList(_context.category, "ID", "ID", serviceModel.ProductCategoryID);
            return View(serviceModel);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Service.FindAsync(id);
            if (serviceModel == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryID"] = new SelectList(_context.category, "ID", "ID", serviceModel.ProductCategoryID);
            return View(serviceModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductCategoryID,Name,Discription,PhoneNumber,picture")] ServiceModel serviceModel)
        {
            if (id != serviceModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (serviceModel.picture != "" || serviceModel.picture != null)
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
                                    serviceModel.picture = PictureName;
                                }

                            }
                        }
                    }

                    _context.Update(serviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceModelExists(serviceModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryID"] = new SelectList(_context.category, "ID", "ID", serviceModel.ProductCategoryID);
            return View(serviceModel);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.Service
                .Include(s => s.ProductCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceModel = await _context.Service.FindAsync(id);
            _context.Service.Remove(serviceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceModelExists(int id)
        {
            return _context.Service.Any(e => e.ID == id);
        }
    }
}

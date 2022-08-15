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
    public class CategoryController : Controller
    {
        private readonly CleanasiaContext _context;

        public CategoryController(CleanasiaContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.category.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Discription,picture")] CategoryModel categoryModel)
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
                            categoryModel.picture = PictureName;
                        }
                    }
                }

                _context.Add(categoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryModel);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.category.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }
            return View(categoryModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Discription,picture")] CategoryModel categoryModel)
        {
            if (id != categoryModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categoryModel.picture != "" || categoryModel.picture != null)
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
                                    categoryModel.picture = PictureName;
                                }

                            }
                        }
                    }

                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.ID))
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
            return View(categoryModel);
        }

        // GET: Category/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nht_lesson10.Models;

namespace Nht_lesson10.Controllers
{
    public class NhtCategoriesController : Controller
    {
        private readonly NhtK23cnt2lesson10Context _context;

        public NhtCategoriesController(NhtK23cnt2lesson10Context context)
        {
            _context = context;
        }

        // GET: NhtCategories
        public async Task<IActionResult> NhtIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NhtCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NhtCategories/Create
        public IActionResult NhtCreate()
        {
            return View();
        }

        // POST: NhtCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtCreate([Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhtIndex));
            }
            return View(category);
        }

        // GET: NhtCategories/Edit/5
        public async Task<IActionResult> NhtEdit(int? nhtId)
        {
            if (nhtId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(nhtId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NhtCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtEdit(int nhtId, [Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (nhtId != category.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NhtIndex));
            }
            return View(category);
        }

        // GET: NhtCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NhtCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CateId == id);
        }
    }
}

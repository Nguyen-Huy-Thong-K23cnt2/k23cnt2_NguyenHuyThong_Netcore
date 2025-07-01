using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenHuyThong_2310900102.Models;

namespace NguyenHuyThong_2310900102.Controllers
{
    public class NhtEmployeesController : Controller
    {
        private readonly NguyenHuyThong231090012Context _context;

        public NhtEmployeesController(NguyenHuyThong231090012Context context)
        {
            _context = context;
        }

        // GET: NhtEmployees
        public async Task<IActionResult> NhtIndex()
        {
            return View(await _context.NhtEmployees.ToListAsync());
        }

        // GET: NhtEmployees/Details/5
        public async Task<IActionResult> NhtDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhtEmployee = await _context.NhtEmployees
                .FirstOrDefaultAsync(m => m.NhtEmpId == id);
            if (nhtEmployee == null)
            {
                return NotFound();
            }

            return View(nhtEmployee);
        }

        // GET: NhtEmployees/Create
        public IActionResult NhtCreate()
        {
            return View();
        }

        // POST: NhtEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtCreate([Bind("NhtEmpId,NhtEmpName,NhtEmpLevel,NhtEmpStartDate,NhtEmpStatus")] NhtEmployee nhtEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhtEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhtIndex));
            }
            return View(nhtEmployee);
        }

        // GET: NhtEmployees/Edit/5
        public async Task<IActionResult> NhtEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhtEmployee = await _context.NhtEmployees.FindAsync(id);
            if (nhtEmployee == null)
            {
                return NotFound();
            }
            return View(nhtEmployee);
        }

        // POST: NhtEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhtEdit(string id, [Bind("NhtEmpId,NhtEmpName,NhtEmpLevel,NhtEmpStartDate,NhtEmpStatus")] NhtEmployee nhtEmployee)
        {
            if (id != nhtEmployee.NhtEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhtEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhtEmployeeExists(nhtEmployee.NhtEmpId))
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
            return View(nhtEmployee);
        }

        // GET: NhtEmployees/Delete/5
        public async Task<IActionResult> NhtDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhtEmployee = await _context.NhtEmployees
                .FirstOrDefaultAsync(m => m.NhtEmpId == id);
            if (nhtEmployee == null)
            {
                return NotFound();
            }

            return View(nhtEmployee);
        }

        // POST: NhtEmployees/Delete/5
        [HttpPost, ActionName("NhtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhtEmployee = await _context.NhtEmployees.FindAsync(id);
            if (nhtEmployee != null)
            {
                _context.NhtEmployees.Remove(nhtEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NhtIndex));
        }

        private bool NhtEmployeeExists(string id)
        {
            return _context.NhtEmployees.Any(e => e.NhtEmpId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoTMS.Models;

namespace DemoTMS.Controllers
{
    public class MasterVehiclesController : Controller
    {
        private readonly SolutionContext _context;

        public MasterVehiclesController(SolutionContext context)
        {
            _context = context;
        }

        // GET: MasterVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MasterVehicles.ToListAsync());
        }

        // GET: MasterVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterVehicle = await _context.MasterVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (masterVehicle == null)
            {
                return NotFound();
            }

            return View(masterVehicle);
        }

        // GET: MasterVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MasterVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleBrand,Capacity")] MasterVehicle masterVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masterVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masterVehicle);
        }

        // GET: MasterVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterVehicle = await _context.MasterVehicles.FindAsync(id);
            if (masterVehicle == null)
            {
                return NotFound();
            }
            return View(masterVehicle);
        }

        // POST: MasterVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleBrand,Capacity")] MasterVehicle masterVehicle)
        {
            if (id != masterVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masterVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterVehicleExists(masterVehicle.Id))
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
            return View(masterVehicle);
        }

        // GET: MasterVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterVehicle = await _context.MasterVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (masterVehicle == null)
            {
                return NotFound();
            }

            return View(masterVehicle);
        }

        // POST: MasterVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var masterVehicle = await _context.MasterVehicles.FindAsync(id);
            _context.MasterVehicles.Remove(masterVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterVehicleExists(int id)
        {
            return _context.MasterVehicles.Any(e => e.Id == id);
        }
    }
}

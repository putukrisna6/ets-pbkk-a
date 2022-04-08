#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelSweden.Data;
using TravelSweden.Models;

namespace TravelSweden.Controllers
{
    public class FlightRoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FlightRoutes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FlightRoute.Include(f => f.DestAirport).Include(f => f.OriginAirport);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FlightRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoute
                .Include(f => f.DestAirport)
                .Include(f => f.OriginAirport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightRoute == null)
            {
                return NotFound();
            }

            return View(flightRoute);
        }

        // GET: FlightRoutes/Create
        public IActionResult Create()
        {
            ViewData["DestAirportId"] = new SelectList(_context.Airport, "Id", "City");
            ViewData["OriginAirportId"] = new SelectList(_context.Airport, "Id", "City");
            return View();
        }

        // POST: FlightRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Distance,OriginAirportId,DestAirportId")] FlightRoute flightRoute)
        {
            _context.Add(flightRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: FlightRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoute.FindAsync(id);
            if (flightRoute == null)
            {
                return NotFound();
            }
            ViewData["DestAirportId"] = new SelectList(_context.Airport, "Id", "City", flightRoute.DestAirportId);
            ViewData["OriginAirportId"] = new SelectList(_context.Airport, "Id", "City", flightRoute.OriginAirportId);
            return View(flightRoute);
        }

        // POST: FlightRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Distance,OriginAirportId,DestAirportId")] FlightRoute flightRoute)
        {
            if (id != flightRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightRouteExists(flightRoute.Id))
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
            ViewData["DestAirportId"] = new SelectList(_context.Airport, "Id", "City", flightRoute.DestAirportId);
            ViewData["OriginAirportId"] = new SelectList(_context.Airport, "Id", "City", flightRoute.OriginAirportId);
            return View(flightRoute);
        }

        // GET: FlightRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoute
                .Include(f => f.DestAirport)
                .Include(f => f.OriginAirport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightRoute == null)
            {
                return NotFound();
            }

            return View(flightRoute);
        }

        // POST: FlightRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightRoute = await _context.FlightRoute.FindAsync(id);
            _context.FlightRoute.Remove(flightRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightRouteExists(int id)
        {
            return _context.FlightRoute.Any(e => e.Id == id);
        }
    }
}

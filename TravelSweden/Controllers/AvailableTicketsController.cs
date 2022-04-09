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
    public class AvailableTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvailableTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvailableTickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AvailableTicket.Include(a => a.AttachedFlight);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AvailableTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableTicket = await _context.AvailableTicket
                .Include(a => a.AttachedFlight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableTicket == null)
            {
                return NotFound();
            }

            return View(availableTicket);
        }

        // GET: AvailableTickets/Create
        public IActionResult Create()
        {
            ViewData["AttachedFlightId"] = new SelectList(_context.Flight, "Id", "Airline");
            return View();
        }

        // POST: AvailableTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttachedFlightId,Category,Price,IsFreeLuggage,IsFreeFood,IsFreeCancellation")] AvailableTicket availableTicket)
        {
            _context.Add(availableTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: AvailableTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableTicket = await _context.AvailableTicket.FindAsync(id);
            if (availableTicket == null)
            {
                return NotFound();
            }
            ViewData["AttachedFlightId"] = new SelectList(_context.Flight, "Id", "Airline", availableTicket.AttachedFlightId);
            return View(availableTicket);
        }

        // POST: AvailableTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AttachedFlightId,Category,Price,IsFreeLuggage,IsFreeFood,IsFreeCancellation")] AvailableTicket availableTicket)
        {
            if (id != availableTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availableTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailableTicketExists(availableTicket.Id))
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
            ViewData["AttachedFlightId"] = new SelectList(_context.Flight, "Id", "Airline", availableTicket.AttachedFlightId);
            return View(availableTicket);
        }

        // GET: AvailableTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableTicket = await _context.AvailableTicket
                .Include(a => a.AttachedFlight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableTicket == null)
            {
                return NotFound();
            }

            return View(availableTicket);
        }

        // POST: AvailableTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availableTicket = await _context.AvailableTicket.FindAsync(id);
            _context.AvailableTicket.Remove(availableTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailableTicketExists(int id)
        {
            return _context.AvailableTicket.Any(e => e.Id == id);
        }
    }
}

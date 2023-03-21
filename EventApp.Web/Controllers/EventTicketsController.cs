using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventApp.Web.Data;
using EventApp.Web.Models.Domain;
using EventApp.Web.Models.DTO;

namespace EventApp.Web.Controllers
{
    public class EventTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventTickets
        public async Task<IActionResult> Index()
        {
              return View(await _context.EventTickets.ToListAsync());
        }

        public async Task<IActionResult> AddTicketToCart(Guid? id)
        {
            var product = await _context.EventTickets.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedTicket = product,
                EventId = product.Id,
                Quantity = 1
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTicketToCart(AddToShoppingCartDto item)
        {
            return View();
        }

        // GET: EventTickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EventTickets == null)
            {
                return NotFound();
            }

            var eventTicket = await _context.EventTickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventTicket == null)
            {
                return NotFound();
            }

            return View(eventTicket);
        }

        // GET: EventTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Details,CoverImage,City,Street,Price,Rating,Type")] EventTicket eventTicket)
        {
            if (ModelState.IsValid)
            {
                eventTicket.Id = Guid.NewGuid();
                _context.Add(eventTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventTicket);
        }

        // GET: EventTickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EventTickets == null)
            {
                return NotFound();
            }

            var eventTicket = await _context.EventTickets.FindAsync(id);
            if (eventTicket == null)
            {
                return NotFound();
            }
            return View(eventTicket);
        }

        // POST: EventTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,StartDate,EndDate,Details,CoverImage,City,Street,Price,Rating,Type")] EventTicket eventTicket)
        {
            if (id != eventTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTicketExists(eventTicket.Id))
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
            return View(eventTicket);
        }

        // GET: EventTickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EventTickets == null)
            {
                return NotFound();
            }

            var eventTicket = await _context.EventTickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventTicket == null)
            {
                return NotFound();
            }

            return View(eventTicket);
        }

        // POST: EventTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EventTickets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EventTickets'  is null.");
            }
            var eventTicket = await _context.EventTickets.FindAsync(id);
            if (eventTicket != null)
            {
                _context.EventTickets.Remove(eventTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTicketExists(Guid id)
        {
          return _context.EventTickets.Any(e => e.Id == id);
        }
    }
}

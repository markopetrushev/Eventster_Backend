using EventApp.Web.Data;
using EventApp.Web.Models.Domain;
using EventApp.Web.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("events")]
        public async Task<ActionResult<List<EventTicket>>> GetEvents()
        {
            return Ok(await _context.EventTickets.ToListAsync());
        }

        [HttpPost("create")]
        public async Task<ActionResult<List<EventTicket>>> CreateEvent(EventTicket et)
        {
            _context.EventTickets.Add(et);
            await _context.SaveChangesAsync();

            return Ok(await _context.EventTickets.ToListAsync());
        }

        [HttpPut("edit")]
        public async Task<ActionResult<List<EventTicket>>> UpdateEvent(EventTicket et)
        {
            var dbEvent = await _context.EventTickets.FindAsync(et.Id);
            if(dbEvent == null)
            {
                return BadRequest("Event not found");
            }

            dbEvent.EventName = et.EventName;
            dbEvent.StartDate = et.StartDate;
            dbEvent.EndDate = et.EndDate;
            dbEvent.Details = et.Details;
            dbEvent.CoverImage = et.CoverImage;
            dbEvent.City = et.City;
            dbEvent.Street = et.Street;
            dbEvent.Price = et.Price;
            dbEvent.Rating = et.Rating;
            dbEvent.Type = et.Type;

            await _context.SaveChangesAsync();

            return Ok(await _context.EventTickets.ToListAsync());
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<List<EventTicket>>> DeleteEvent(Guid id)
        {
            var dbEvent = await _context.EventTickets.FindAsync(id);
            if (dbEvent == null)
            {
                return BadRequest("Event not found");
            }

            _context.EventTickets.Remove(dbEvent);
            await _context.SaveChangesAsync();

            return Ok(await _context.EventTickets.ToListAsync());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerkstedFinder.Context;
using VerkstedFinder.Model;

namespace VerkstedFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly AndremiContext _context;

        public WorkshopsController(AndremiContext context)
        {
            _context = context;
        }

        // GET: api/Workshops
        [HttpGet]
        public IEnumerable<Workshop> GetWorkshops()
        {
            return _context.Workshops;
        }

        // GET: api/Workshops/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkshop([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workshop = await _context.Workshops.FindAsync(id);

            if (workshop == null)
            {
                return NotFound();
            }

            return Ok(workshop);
        }

        // PUT: api/Workshops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkshop([FromRoute] int id, [FromBody] Workshop workshop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workshop.Ws_id)
            {
                return BadRequest();
            }

            _context.Entry(workshop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workshops
        [HttpPost]
        public async Task<IActionResult> PostWorkshop([FromBody] Workshop workshop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Workshops.Add(workshop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkshop", new { id = workshop.Ws_id }, workshop);
        }

        // DELETE: api/Workshops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkshop([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workshop = await _context.Workshops.FindAsync(id);
            if (workshop == null)
            {
                return NotFound();
            }

            _context.Workshops.Remove(workshop);
            await _context.SaveChangesAsync();

            return Ok(workshop);
        }

        private bool WorkshopExists(int id)
        {
            return _context.Workshops.Any(e => e.Ws_id == id);
        }
    }
}
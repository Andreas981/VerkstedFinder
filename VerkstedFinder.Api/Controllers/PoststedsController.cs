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
    public class PoststedsController : ControllerBase
    {
        private readonly AndremiContext _context;

        public PoststedsController(AndremiContext context)
        {
            _context = context;
        }

        // GET: api/Poststeds
        [HttpGet]
        public IEnumerable<Poststed> GetPoststeds()
        {
            return _context.Poststeds;
        }

        // GET: api/Poststeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoststed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poststed = await _context.Poststeds.FindAsync(id);

            if (poststed == null)
            {
                return NotFound();
            }

            return Ok(poststed);
        }

        // PUT: api/Poststeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoststed([FromRoute] int id, [FromBody] Poststed poststed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poststed.Postnr)
            {
                return BadRequest();
            }

            _context.Entry(poststed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoststedExists(id))
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

        // POST: api/Poststeds
        [HttpPost]
        public async Task<IActionResult> PostPoststed([FromBody] Poststed poststed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Poststeds.Add(poststed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoststed", new { id = poststed.Postnr }, poststed);
        }

        // DELETE: api/Poststeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoststed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var poststed = await _context.Poststeds.FindAsync(id);
            if (poststed == null)
            {
                return NotFound();
            }

            _context.Poststeds.Remove(poststed);
            await _context.SaveChangesAsync();

            return Ok(poststed);
        }

        private bool PoststedExists(int id)
        {
            return _context.Poststeds.Any(e => e.Postnr == id);
        }
    }
}

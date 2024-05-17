using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNetCore6Book.Data;

namespace ApiNetCore6Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookksController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BookksController(BookDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookk>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Bookks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookk>> GetBookk(int id)
        {
            var bookk = await _context.Books.FindAsync(id);

            if (bookk == null)
            {
                return NotFound();
            }

            return bookk;
        }

        // PUT: api/Bookks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookk(int id, Bookk bookk)
        {
            if (id != bookk.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookkExists(id))
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

        // POST: api/Bookks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookk>> PostBookk(Bookk bookk)
        {
            _context.Books.Add(bookk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookk", new { id = bookk.Id }, bookk);
        }

        // DELETE: api/Bookks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookk(int id)
        {
            var bookk = await _context.Books.FindAsync(id);
            if (bookk == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookkExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}

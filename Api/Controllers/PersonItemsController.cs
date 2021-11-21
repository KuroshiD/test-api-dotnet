using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonItemsController : ControllerBase
    {
        private readonly PersonContext _context;

        public PersonItemsController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/PersonItems
        [HttpGet("id")]
        public async Task<ActionResult<PersonItem>> GetTodoItem(long id)
        {
            var todoitem = await _context.PersonItems.FindAsync(id);
            
            if(todoitem == null)
            {
                return NotFound();
            }


            return todoitem;
        }

        // GET: api/PersonItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonItem>> GetPersonItem(int id)
        {
            var personItem = await _context.PersonItems.FindAsync(id);

            if (personItem == null)
            {
                return NotFound();
            }

            return personItem;
        }

        // PUT: api/PersonItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonItem(int id, PersonItem personItem)
        {
            if (id != personItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(personItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonItemExists(id))
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

        // POST: api/PersonItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonItem>> PostPersonItem(PersonItem personItem)
        {
            _context.PersonItems.Add(personItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonItem), new { id = personItem.Id }, personItem);
        }

        // DELETE: api/PersonItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonItem(int id)
        {
            var personItem = await _context.PersonItems.FindAsync(id);
            if (personItem == null)
            {
                return NotFound();
            }

            _context.PersonItems.Remove(personItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonItemExists(int id)
        {
            return _context.PersonItems.Any(e => e.Id == id);
        }
    }
}

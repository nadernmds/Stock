using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Models;

namespace Stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public StateController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/State
        [HttpGet]
        public async Task<ActionResult<IEnumerable<States>>> GetStates()
        {
            return await db.States.ToListAsync();
        }

        // GET: api/State/5
        [HttpGet("{id}")]
        public async Task<ActionResult<States>> GetStates(int id)
        {
            var states = await db.States.FindAsync(id);

            if (states == null)
            {
                return NotFound();
            }

            return states;
        }

        // PUT: api/State/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStates(int id, States states)
        {
            if (id != states.StateId)
            {
                return BadRequest();
            }

            db.Entry(states).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatesExists(id))
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

        // POST: api/State
        [HttpPost]
        public async Task<ActionResult<States>> PostStates(States states)
        {
            db.States.Add(states);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetStates", new { id = states.StateId }, states);
        }

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<States>> DeleteStates(int id)
        {
            var states = await db.States.FindAsync(id);
            if (states == null)
            {
                return NotFound();
            }

            db.States.Remove(states);
            await db.SaveChangesAsync();

            return states;
        }

        private bool StatesExists(int id)
        {
            return db.States.Any(e => e.StateId == id);
        }
    }
}

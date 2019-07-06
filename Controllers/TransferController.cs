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
    public class TransferController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public TransferController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/Transfer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transfers>>> GetTransfers()
        {
            return await db.Transfers.ToListAsync();
        }

        // GET: api/Transfer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transfers>> GetTransfers(int id)
        {
            var transfers = await db.Transfers.FindAsync(id);

            if (transfers == null)
            {
                return NotFound();
            }

            return transfers;
        }

        // PUT: api/Transfer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransfers(int id, Transfers transfers)
        {
            if (id != transfers.TransferId)
            {
                return BadRequest();
            }

            db.Entry(transfers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransfersExists(id))
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

        // POST: api/Transfer
        [HttpPost]
        public async Task<ActionResult<Transfers>> PostTransfers(Transfers transfers)
        {
            db.Transfers.Add(transfers);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetTransfers", new { id = transfers.TransferId }, transfers);
        }

        // DELETE: api/Transfer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transfers>> DeleteTransfers(int id)
        {
            var transfers = await db.Transfers.FindAsync(id);
            if (transfers == null)
            {
                return NotFound();
            }

            db.Transfers.Remove(transfers);
            await db.SaveChangesAsync();

            return transfers;
        }

        private bool TransfersExists(int id)
        {
            return db.Transfers.Any(e => e.TransferId == id);
        }
    }
}

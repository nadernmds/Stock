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
    public class BankController : ControllerBase
    {
        private Stock_dbContext db = new Stock_dbContext();


        // GET: api/Bank
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banks>>> GetBanks()
        {
            return await db.Banks.ToListAsync();
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banks>> GetBanks(int id)
        {
            var banks = await db.Banks.FindAsync(id);

            if (banks == null)
            {
                return NotFound();
            }

            return banks;
        }

        // PUT: api/Bank/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanks(int id, Banks banks)
        {
            if (id != banks.BankId)
            {
                return BadRequest();
            }

            db.Entry(banks).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanksExists(id))
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

        // POST: api/Bank
        [HttpPost]
        public async Task<ActionResult<Banks>> PostBanks(Banks banks)
        {
            db.Banks.Add(banks);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetBanks", new { id = banks.BankId }, banks);
        }

        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banks>> DeleteBanks(int id)
        {
            var banks = await db.Banks.FindAsync(id);
            if (banks == null)
            {
                return NotFound();
            }

            db.Banks.Remove(banks);
            await db.SaveChangesAsync();

            return banks;
        }

        private bool BanksExists(int id)
        {
            return db.Banks.Any(e => e.BankId == id);
        }
    }
}

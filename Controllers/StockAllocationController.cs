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
    public class StockAllocationController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public StockAllocationController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/StockAllocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockAllocations>>> GetStockAllocations()
        {
            return await db.StockAllocations.ToListAsync();
        }

        // GET: api/StockAllocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockAllocations>> GetStockAllocations(long id)
        {
            var stockAllocations = await db.StockAllocations.FindAsync(id);

            if (stockAllocations == null)
            {
                return NotFound();
            }

            return stockAllocations;
        }

        // PUT: api/StockAllocation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockAllocations(long id, StockAllocations stockAllocations)
        {
            if (id != stockAllocations.StockAllocationId)
            {
                return BadRequest();
            }

            db.Entry(stockAllocations).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockAllocationsExists(id))
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

        // POST: api/StockAllocation
        [HttpPost]
        public async Task<ActionResult<StockAllocations>> PostStockAllocations(StockAllocations stockAllocations)
        {
            db.StockAllocations.Add(stockAllocations);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetStockAllocations", new { id = stockAllocations.StockAllocationId }, stockAllocations);
        }

        // DELETE: api/StockAllocation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockAllocations>> DeleteStockAllocations(long id)
        {
            var stockAllocations = await db.StockAllocations.FindAsync(id);
            if (stockAllocations == null)
            {
                return NotFound();
            }

            db.StockAllocations.Remove(stockAllocations);
            await db.SaveChangesAsync();

            return stockAllocations;
        }

        private bool StockAllocationsExists(long id)
        {
            return db.StockAllocations.Any(e => e.StockAllocationId == id);
        }
    }
}

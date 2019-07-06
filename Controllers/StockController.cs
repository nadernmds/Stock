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
    public class StockController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public StockController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stocks>>> GetStocks()
        {
            return await db.Stocks.ToListAsync();
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stocks>> GetStocks(int id)
        {
            var stocks = await db.Stocks.FindAsync(id);

            if (stocks == null)
            {
                return NotFound();
            }

            return stocks;
        }

        // PUT: api/Stock/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStocks(int id, Stocks stocks)
        {
            if (id != stocks.StockId)
            {
                return BadRequest();
            }

            db.Entry(stocks).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StocksExists(id))
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

        // POST: api/Stock
        [HttpPost]
        public async Task<ActionResult<Stocks>> PostStocks(Stocks stocks)
        {
            db.Stocks.Add(stocks);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetStocks", new { id = stocks.StockId }, stocks);
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stocks>> DeleteStocks(int id)
        {
            var stocks = await db.Stocks.FindAsync(id);
            if (stocks == null)
            {
                return NotFound();
            }

            db.Stocks.Remove(stocks);
            await db.SaveChangesAsync();

            return stocks;
        }

        private bool StocksExists(int id)
        {
            return db.Stocks.Any(e => e.StockId == id);
        }
    }
}

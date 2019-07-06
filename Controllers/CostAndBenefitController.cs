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
    public class CostAndBenefitController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public CostAndBenefitController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/CostAndBenefit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostAndBenefits>>> GetCostAndBenefits()
        {
            return await db.CostAndBenefits.ToListAsync();
        }

        // GET: api/CostAndBenefit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CostAndBenefits>> GetCostAndBenefits(int id)
        {
            var costAndBenefits = await db.CostAndBenefits.FindAsync(id);

            if (costAndBenefits == null)
            {
                return NotFound();
            }

            return costAndBenefits;
        }

        // PUT: api/CostAndBenefit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostAndBenefits(int id, CostAndBenefits costAndBenefits)
        {
            if (id != costAndBenefits.CostAndBenefitId)
            {
                return BadRequest();
            }

            db.Entry(costAndBenefits).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostAndBenefitsExists(id))
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

        // POST: api/CostAndBenefit
        [HttpPost]
        public async Task<ActionResult<CostAndBenefits>> PostCostAndBenefits(CostAndBenefits costAndBenefits)
        {
            db.CostAndBenefits.Add(costAndBenefits);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetCostAndBenefits", new { id = costAndBenefits.CostAndBenefitId }, costAndBenefits);
        }

        // DELETE: api/CostAndBenefit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CostAndBenefits>> DeleteCostAndBenefits(int id)
        {
            var costAndBenefits = await db.CostAndBenefits.FindAsync(id);
            if (costAndBenefits == null)
            {
                return NotFound();
            }

            db.CostAndBenefits.Remove(costAndBenefits);
            await db.SaveChangesAsync();

            return costAndBenefits;
        }

        private bool CostAndBenefitsExists(int id)
        {
            return db.CostAndBenefits.Any(e => e.CostAndBenefitId == id);
        }
    }
}

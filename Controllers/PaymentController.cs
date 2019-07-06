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
    public class PaymentController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public PaymentController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPayments()
        {
            return await db.Payments.ToListAsync();
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetPayments(long id)
        {
            var payments = await db.Payments.FindAsync(id);

            if (payments == null)
            {
                return NotFound();
            }

            return payments;
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayments(long id, Payments payments)
        {
            if (id != payments.PaymentId)
            {
                return BadRequest();
            }

            db.Entry(payments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsExists(id))
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

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<Payments>> PostPayments(Payments payments)
        {
            db.Payments.Add(payments);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetPayments", new { id = payments.PaymentId }, payments);
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payments>> DeletePayments(long id)
        {
            var payments = await db.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payments);
            await db.SaveChangesAsync();

            return payments;
        }

        private bool PaymentsExists(long id)
        {
            return db.Payments.Any(e => e.PaymentId == id);
        }
    }
}

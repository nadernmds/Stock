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
    public class PaymentTypeController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public PaymentTypeController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTypes>>> GetPaymentTypes()
        {
            return await db.PaymentTypes.ToListAsync();
        }

        // GET: api/PaymentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTypes>> GetPaymentTypes(int id)
        {
            var paymentTypes = await db.PaymentTypes.FindAsync(id);

            if (paymentTypes == null)
            {
                return NotFound();
            }

            return paymentTypes;
        }

        // PUT: api/PaymentType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTypes(int id, PaymentTypes paymentTypes)
        {
            if (id != paymentTypes.PaymentTypeId)
            {
                return BadRequest();
            }

            db.Entry(paymentTypes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypesExists(id))
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

        // POST: api/PaymentType
        [HttpPost]
        public async Task<ActionResult<PaymentTypes>> PostPaymentTypes(PaymentTypes paymentTypes)
        {
            db.PaymentTypes.Add(paymentTypes);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTypes", new { id = paymentTypes.PaymentTypeId }, paymentTypes);
        }

        // DELETE: api/PaymentType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentTypes>> DeletePaymentTypes(int id)
        {
            var paymentTypes = await db.PaymentTypes.FindAsync(id);
            if (paymentTypes == null)
            {
                return NotFound();
            }

            db.PaymentTypes.Remove(paymentTypes);
            await db.SaveChangesAsync();

            return paymentTypes;
        }

        private bool PaymentTypesExists(int id)
        {
            return db.PaymentTypes.Any(e => e.PaymentTypeId == id);
        }
    }
}

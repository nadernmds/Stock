using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Models;
using pep;
using Microsoft.AspNetCore.Authorization;

namespace Stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private Stock_dbContext db = new Stock_dbContext();




        //public async Task<IEnumerable<Payments>> GeneratePayments(int id)
        //{

        //}

        // GET: api/Payment
        [HttpGet,Authorize]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPayments()
        {
            var s = await db.InstalmentTemplates.FindAsync(1);
            var startdate = s.FromDate.Value.ToPersianDateShortString().Substring(0, 8) + "01";
            var aghsatStartDate = startdate.toMiladiDate().AddDays(Convert.ToInt32(s.Payday)-1);
            var sDate = s.FromDate.Value;
            int count = s.Count.Value;
            while (count>0)
            {
                if (aghsatStartDate < s.FromDate)
                {
                    continue;
                }
                else
                {
                    db.Payments.Add(new Payments()
                    {
                        Date= aghsatStartDate,Amount=s.Amount,Title="قسط شماره ",UserId=Convert.ToInt32( User.Identity.Name)

                    });
                    var ww = aghsatStartDate.AddDays(30).toPersianDateString();
                
                }
                count--;                    aghsatStartDate = aghsatStartDate.AddDays(30);

            }
            db.SaveChanges();
            if (aghsatStartDate > s.FromDate)
            {

            }
            return await db.Payments.ToListAsync();
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPaymentsAsync(int id)
        {
            var payments = await db.Payments.Where(c => c.UserId == id).ToListAsync();

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

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
    public class ApproveUserPaymentController : ControllerBase
    {
        private  Stock_dbContext db=new Stock_dbContext();

        public ApproveUserPaymentController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/ApproveUserPayment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApproveUserPayments>>> GetApproveUserPayments()
        {
            return await db.ApproveUserPayments.ToListAsync();
        }

        // GET: api/ApproveUserPayment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApproveUserPayments>> GetApproveUserPayments(int id)
        {
            var approveUserPayments = await db.ApproveUserPayments.FindAsync(id);

            if (approveUserPayments == null)
            {
                return NotFound();
            }

            return approveUserPayments;
        }

        // PUT: api/ApproveUserPayment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApproveUserPayments(int id, ApproveUserPayments approveUserPayments)
        {
            if (id != approveUserPayments.ApproveUserPaymentsId)
            {
                return BadRequest();
            }

            db.Entry(approveUserPayments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApproveUserPaymentsExists(id))
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

        // POST: api/ApproveUserPayment
        [HttpPost]
        public async Task<ActionResult<ApproveUserPayments>> PostApproveUserPayments(ApproveUserPayments approveUserPayments)
        {
            db.ApproveUserPayments.Add(approveUserPayments);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetApproveUserPayments", new { id = approveUserPayments.ApproveUserPaymentsId }, approveUserPayments);
        }

        // DELETE: api/ApproveUserPayment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApproveUserPayments>> DeleteApproveUserPayments(int id)
        {
            var approveUserPayments = await db.ApproveUserPayments.FindAsync(id);
            if (approveUserPayments == null)
            {
                return NotFound();
            }

            db.ApproveUserPayments.Remove(approveUserPayments);
            await db.SaveChangesAsync();

            return approveUserPayments;
        }

        private bool ApproveUserPaymentsExists(int id)
        {
            return db.ApproveUserPayments.Any(e => e.ApproveUserPaymentsId == id);
        }
    }
}

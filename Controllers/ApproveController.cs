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
    public class ApproveController : ControllerBase
    {
        private  Stock_dbContext db=new Stock_dbContext();



        // GET: api/Approve
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Approves>>> GetApproves()
        {
            return await db.Approves.ToListAsync();
        }



        // GET: api/Approve/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Approves>> GetApproves(int id)
        {
            var approves = await db.Approves.FindAsync(id);

            if (approves == null)
            {
                return NotFound();
            }

            return approves;
        }

        // PUT: api/Approve/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApproves(int id, Approves approves)
        {
            if (id != approves.ApproveId)
            {
                return BadRequest();
            }

            db.Entry(approves).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovesExists(id))
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

        // POST: api/Approve
        [HttpPost]
        public async Task<ActionResult<Approves>> PostApproves(Approves approves)
        {
            db.Approves.Add(approves);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetApproves", new { id = approves.ApproveId }, approves);
        }

        // DELETE: api/Approve/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Approves>> DeleteApproves(int id)
        {
            var approves = await db.Approves.FindAsync(id);
            if (approves == null)
            {
                return NotFound();
            }

            db.Approves.Remove(approves);
            await db.SaveChangesAsync();

            return approves;
        }

        private bool ApprovesExists(int id)
        {
            return db.Approves.Any(e => e.ApproveId == id);
        }
    }
}

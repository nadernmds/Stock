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
    public class FaqController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();



        // GET: api/Faq
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faqs>>> GetFaqs()
        {
            return await db.Faqs.ToListAsync();
        }

        // GET: api/Faq/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faqs>> GetFaqs(int id)
        {
            var faqs = await db.Faqs.FindAsync(id);

            if (faqs == null)
            {
                return NotFound();
            }

            return faqs;
        }

        // PUT: api/Faq/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaqs(int id, Faqs faqs)
        {
            if (id != faqs.FaqId)
            {
                return BadRequest();
            }

            db.Entry(faqs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaqsExists(id))
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

        // POST: api/Faq
        [HttpPost]
        public async Task<ActionResult<Faqs>> PostFaqs(Faqs faqs)
        {
            db.Faqs.Add(faqs);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetFaqs", new { id = faqs.FaqId }, faqs);
        }

        // DELETE: api/Faq/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Faqs>> DeleteFaqs(int id)
        {
            var faqs = await db.Faqs.FindAsync(id);
            if (faqs == null)
            {
                return NotFound();
            }

            db.Faqs.Remove(faqs);
            await db.SaveChangesAsync();

            return faqs;
        }

        private bool FaqsExists(int id)
        {
            return db.Faqs.Any(e => e.FaqId == id);
        }
    }
}

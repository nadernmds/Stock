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
    public class InstalmentTemplateController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public InstalmentTemplateController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/InstalmentTemplate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstalmentTemplates>>> GetInstalmentTemplates()
        {
            return await db.InstalmentTemplates.ToListAsync();
        }

        // GET: api/InstalmentTemplate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstalmentTemplates>> GetInstalmentTemplates(int id)
        {
            var instalmentTemplates = await db.InstalmentTemplates.FindAsync(id);

            if (instalmentTemplates == null)
            {
                return NotFound();
            }

            return instalmentTemplates;
        }

        // PUT: api/InstalmentTemplate/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalmentTemplates(int id, InstalmentTemplates instalmentTemplates)
        {
            if (id != instalmentTemplates.InstalmentTemplateId)
            {
                return BadRequest();
            }

            db.Entry(instalmentTemplates).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalmentTemplatesExists(id))
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

        // POST: api/InstalmentTemplate
        [HttpPost]
        public async Task<ActionResult<InstalmentTemplates>> PostInstalmentTemplates(InstalmentTemplates instalmentTemplates)
        {
            db.InstalmentTemplates.Add(instalmentTemplates);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetInstalmentTemplates", new { id = instalmentTemplates.InstalmentTemplateId }, instalmentTemplates);
        }

        // DELETE: api/InstalmentTemplate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstalmentTemplates>> DeleteInstalmentTemplates(int id)
        {
            var instalmentTemplates = await db.InstalmentTemplates.FindAsync(id);
            if (instalmentTemplates == null)
            {
                return NotFound();
            }

            db.InstalmentTemplates.Remove(instalmentTemplates);
            await db.SaveChangesAsync();

            return instalmentTemplates;
        }

        private bool InstalmentTemplatesExists(int id)
        {
            return db.InstalmentTemplates.Any(e => e.InstalmentTemplateId == id);
        }
    }
}

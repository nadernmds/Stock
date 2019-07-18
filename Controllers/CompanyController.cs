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
    public class CompanyController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();
        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companies>>> GetCompanies()
        {
            HttpContext.Session.SetString("pep", "pep");
            return await db.Companies.ToListAsync();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompanies(int id)
        {
            var companies = await db.Companies.FindAsync(id);
          var w=  HttpContext.Session.GetString("pep");
            if (companies == null)
            {
                return NotFound();
            }

            return companies;
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(int id, Companies companies)
        {
            if (id != companies.CompanyId)
            {
                return BadRequest();
            }

            db.Entry(companies).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompaniesExists(id))
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

        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompanies(Companies companies)
        {
            db.Companies.Add(companies);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetCompanies", new { id = companies.CompanyId }, companies);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Companies>> DeleteCompanies(int id)
        {
            var companies = await db.Companies.FindAsync(id);
            if (companies == null)
            {
                return NotFound();
            }

            db.Companies.Remove(companies);
            await db.SaveChangesAsync();

            return companies;
        }

        private bool CompaniesExists(int id)
        {
            return db.Companies.Any(e => e.CompanyId == id);
        }
    }
}

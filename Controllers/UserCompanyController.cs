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
    public class UserCompanyController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public UserCompanyController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/UserCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCompanies>>> GetUserCompanies()
        {
            return await db.UserCompanies.ToListAsync();
        }

        // GET: api/UserCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCompanies>> GetUserCompanies(int id)
        {
            var userCompanies = await db.UserCompanies.FindAsync(id);

            if (userCompanies == null)
            {
                return NotFound();
            }

            return userCompanies;
        }

        // PUT: api/UserCompany/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCompanies(int id, UserCompanies userCompanies)
        {
            if (id != userCompanies.UserCompanyId)
            {
                return BadRequest();
            }

            db.Entry(userCompanies).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCompaniesExists(id))
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

        // POST: api/UserCompany
        [HttpPost]
        public async Task<ActionResult<UserCompanies>> PostUserCompanies(UserCompanies userCompanies)
        {
            db.UserCompanies.Add(userCompanies);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetUserCompanies", new { id = userCompanies.UserCompanyId }, userCompanies);
        }

        // DELETE: api/UserCompany/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCompanies>> DeleteUserCompanies(int id)
        {
            var userCompanies = await db.UserCompanies.FindAsync(id);
            if (userCompanies == null)
            {
                return NotFound();
            }

            db.UserCompanies.Remove(userCompanies);
            await db.SaveChangesAsync();

            return userCompanies;
        }

        private bool UserCompaniesExists(int id)
        {
            return db.UserCompanies.Any(e => e.UserCompanyId == id);
        }
    }
}

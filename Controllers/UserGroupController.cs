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
    public class UserGroupController : ControllerBase
    {
        private Stock_dbContext db = new Stock_dbContext();


        // GET: api/UserGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroups>>> GetUserGroups()
        {
            return await db.UserGroups.ToListAsync();
        }

        // GET: api/UserGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroups>> GetUserGroups(int id)
        {
            var userGroups = await db.UserGroups.FindAsync(id);

            if (userGroups == null)
            {
                return NotFound();
            }

            return userGroups;
        }

        // PUT: api/UserGroup/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroups(int id, UserGroups userGroups)
        {
            if (id != userGroups.UserGroupId)
            {
                return BadRequest();
            }

            db.Entry(userGroups).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupsExists(id))
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

        // POST: api/UserGroup
        [HttpPost]
        public async Task<ActionResult<UserGroups>> PostUserGroups(UserGroups userGroups)
        {
            db.UserGroups.Add(userGroups);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetUserGroups", new { id = userGroups.UserGroupId }, userGroups);
        }

        // DELETE: api/UserGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserGroups>> DeleteUserGroups(int id)
        {
            var userGroups = await db.UserGroups.FindAsync(id);
            if (userGroups == null)
            {
                return NotFound();
            }

            db.UserGroups.Remove(userGroups);
            await db.SaveChangesAsync();

            return userGroups;
        }

        private bool UserGroupsExists(int id)
        {
            return db.UserGroups.Any(e => e.UserGroupId == id);
        }
    }
}

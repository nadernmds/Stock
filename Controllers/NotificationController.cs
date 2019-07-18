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
    public class NotificationController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();



        // GET: api/Notification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notifications>>> GetNotifications()
        {
            return await db.Notifications.ToListAsync();
        }

        // GET: api/Notification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notifications>> GetNotifications(int id)
        {
            var notifications = await db.Notifications.FindAsync(id);

            if (notifications == null)
            {
                return NotFound();
            }

            return notifications;
        }

        // PUT: api/Notification/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotifications(int id, Notifications notifications)
        {
            if (id != notifications.NotificationId)
            {
                return BadRequest();
            }

            db.Entry(notifications).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationsExists(id))
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

        // POST: api/Notification
        [HttpPost]
        public async Task<ActionResult<Notifications>> PostNotifications(Notifications notifications)
        {
            db.Notifications.Add(notifications);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetNotifications", new { id = notifications.NotificationId }, notifications);
        }

        // DELETE: api/Notification/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notifications>> DeleteNotifications(int id)
        {
            var notifications = await db.Notifications.FindAsync(id);
            if (notifications == null)
            {
                return NotFound();
            }

            db.Notifications.Remove(notifications);
            await db.SaveChangesAsync();

            return notifications;
        }

        private bool NotificationsExists(int id)
        {
            return db.Notifications.Any(e => e.NotificationId == id);
        }
    }
}

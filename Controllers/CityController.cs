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
    public class CityController : ControllerBase
    {
        private Stock_dbContext db=new Stock_dbContext();

        public CityController(Stock_dbContext context)
        {
            db = context;
        }

        // GET: api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cities>>> GetCities()
        {
            return await db.Cities.ToListAsync();
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> GetCities(int id)
        {
            var cities = await db.Cities.FindAsync(id);

            if (cities == null)
            {
                return NotFound();
            }

            return cities;
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCities(int id, Cities cities)
        {
            if (id != cities.CityId)
            {
                return BadRequest();
            }

            db.Entry(cities).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitiesExists(id))
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

        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<Cities>> PostCities(Cities cities)
        {
            db.Cities.Add(cities);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetCities", new { id = cities.CityId }, cities);
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cities>> DeleteCities(int id)
        {
            var cities = await db.Cities.FindAsync(id);
            if (cities == null)
            {
                return NotFound();
            }

            db.Cities.Remove(cities);
            await db.SaveChangesAsync();

            return cities;
        }

        private bool CitiesExists(int id)
        {
            return db.Cities.Any(e => e.CityId == id);
        }
    }
}

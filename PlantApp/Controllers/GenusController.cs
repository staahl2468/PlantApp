using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantApp.Models;

namespace PlantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenusController : Controller
    {
        private readonly PlantContext _context;

        public GenusController(PlantContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllGenus")]
        public async Task<ActionResult<List<Genus>>> Get()
        {
            return Ok(await _context.Genus.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genus>> Get(int id)
        {
            var genus = await _context.Genus.FindAsync(id);
            if (genus == null)
                return BadRequest("Genus not found.");
            return Ok(genus);
        }
        
        [HttpPost("AddGenus")]
        public async Task<ActionResult<List<Genus>>> AddGenus(Genus genus)
        {
            _context.Genus.Add(genus);
            await _context.SaveChangesAsync();

            return Ok(await _context.Genus.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Genus>>> UpdateGenus(Genus request)
        {
            var dbGenus = await _context.Genus.FindAsync(request.Id);
            if (dbGenus == null)
                return BadRequest("Genus not found.");

            dbGenus.Name = request.Name;
            dbGenus.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Genus.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Genus>>> Delete(int id)
        {
            var dbGenus = await _context.Genus.FindAsync(id);
            if (dbGenus == null)
                return BadRequest("Genus not found.");

            _context.Genus.Remove(dbGenus);
            await _context.SaveChangesAsync();

            return Ok(await _context.Genus.ToListAsync());
        }
    }
}

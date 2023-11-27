using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantApp.Models;

namespace PlantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoilController : Controller
    {
        private readonly PlantContext _context;

        public SoilController(PlantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Soil>>> Get()
        {
            return Ok(await _context.Soil.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Soil>> Get(int id)
        {
            var soil = await _context.Soil.FindAsync(id);
            if (soil == null)
                return BadRequest("Soil not found.");
            return Ok(soil);
        }

        [HttpPost]
        public async Task<ActionResult<List<Soil>>> AddSoil(Soil soil)
        {
            _context.Soil.Add(soil);
            await _context.SaveChangesAsync();

            return Ok(await _context.Soil.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Soil>>> UpdateSoil(Soil request)
        {
            var dbSoil = await _context.Soil.FindAsync(request.Id);
            if (dbSoil == null)
                return BadRequest("Soil not found.");

            dbSoil.Name = request.Name;
            dbSoil.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Soil.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Soil>>> Delete(int id)
        {
            var dbSoil = await _context.Soil.FindAsync(id);
            if (dbSoil == null)
                return BadRequest("Soil not found.");

            _context.Soil.Remove(dbSoil);
            await _context.SaveChangesAsync();

            return Ok(await _context.Soil.ToListAsync());
        }
    }
}

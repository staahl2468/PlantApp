using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantApp.Models;

namespace PlantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeafController : Controller
    {
        private readonly PlantContext _context;

        public LeafController(PlantContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Leaf>>> Get()
        {
            return Ok(await _context.Leaf.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leaf>> Get(int id)
        {
            var leaf = await _context.Leaf.FindAsync(id);
            if (leaf == null)
                return BadRequest("Leaf not found.");
            return Ok(leaf);
        }

        [HttpPost]
        public async Task<ActionResult<List<Leaf>>> AddLeaf(Leaf leaf)
        {
            _context.Leaf.Add(leaf);
            await _context.SaveChangesAsync();

            return Ok(await _context.Leaf.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Leaf>>> UpdateLeaf(Leaf request)
        {
            var dbLeaf = await _context.Soil.FindAsync(request.Id);
            if (dbLeaf == null)
                return BadRequest("Leaf not found.");

            dbLeaf.Name = request.Name;
            dbLeaf.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Leaf.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Leaf>>> Delete(int id)
        {
            var dbLeaf = await _context.Leaf.FindAsync(id);
            if (dbLeaf == null)
                return BadRequest("Leaf not found.");

            _context.Leaf.Remove(dbLeaf);
            await _context.SaveChangesAsync();

            return Ok(await _context.Leaf.ToListAsync());
        }
    }
}

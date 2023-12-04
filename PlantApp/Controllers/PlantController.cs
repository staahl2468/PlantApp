using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantApp.Data;
using PlantApp.Models;

namespace PlantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : Controller
    {
        
        private readonly PlantContext _context;

        public PlantController(PlantContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllPlants")]
        public async Task<ActionResult<List<Plant>>> Get()
        {
            return Ok(await _context.Plant.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> Get(int id)
        {
            var plant = await _context.Plant.FindAsync(id);
            if (plant == null)
                return BadRequest("Plant not found.");
            return Ok(plant);
        }

        [HttpPost("AddPlant")]
        public async Task<ActionResult<List<Plant>>> AddPlant(Plant plant)
        {
            // Check if Genus, Leaf, and Soil with the provided IDs exist in the database
            var existingGenus = await _context.Genus.FindAsync(plant.GenusId);
            var existingLeaf = await _context.Leaf.FindAsync(plant.LeafId);
            var existingSoil = await _context.Soil.FindAsync(plant.SoilId);

            // If any of them doesn't exist, return a 404 Not Found response
            if (existingGenus == null || existingLeaf == null || existingSoil == null)
            {
                return NotFound("One or more entities not found. Plant creation failed.");
            }

            // Set the relationships in the Plant entity
            plant.Genus = existingGenus;
            plant.Leaf = existingLeaf;
            plant.Soil = existingSoil;
            // Add the Plant entity
            _context.Plant.Add(plant);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of plants
            return Ok(await _context.Plant.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Plant>>> UpdatePlant(Plant request)
        {
            var dbPlant = await _context.Plant.FindAsync(request.Id);
            if (dbPlant == null)
                return BadRequest("Plant not found.");
            var existingGenus = await _context.Genus.FindAsync(request.GenusId);
            var existingLeaf = await _context.Leaf.FindAsync(request.LeafId);
            var existingSoil = await _context.Soil.FindAsync(request.SoilId);

            if (existingGenus == null || existingLeaf == null || existingSoil == null)
            {
                return NotFound("One or more entities not found. Plant creation failed.");
            }

            dbPlant.Name = request.Name;
            dbPlant.SoilId = request.SoilId;
            dbPlant.LeafId = request.LeafId;
            dbPlant.GenusId = request.GenusId;

            dbPlant.Genus = existingGenus;
            dbPlant.Leaf = existingLeaf;
            dbPlant.Soil = existingSoil;

            await _context.SaveChangesAsync();

            return Ok(await _context.Plant.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Plant>>> Delete(int id)
        {
            var dbPlant = await _context.Plant.FindAsync(id);
            if (dbPlant == null)
                return BadRequest("Plant not found.");

            _context.Plant.Remove(dbPlant);
            await _context.SaveChangesAsync();

            return Ok(await _context.Plant.ToListAsync());
        }




    }
}

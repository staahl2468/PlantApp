using Microsoft.EntityFrameworkCore;
using PlantApp.Models;

namespace PlantApp.Data
{
    public class PlantContext : DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options) : base(options) { }

        public DbSet<Plant> Plant { get; set; }
        public DbSet<Soil> Soil { get; set; }
        public DbSet<Leaf> Leaf { get; set; }
        public DbSet<Genus> Genus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genus>()
                .HasMany(g => g.Plants)
                .WithOne(p => p.Genus)
                .HasForeignKey(p => p.GenusId);

            modelBuilder.Entity<Soil>()
                .HasMany(s => s.Plants)
                .WithOne(p => p.Soil)
                .HasForeignKey(p => p.SoilId);

            modelBuilder.Entity<Leaf>()
                .HasMany(l => l.Plants)
                .WithOne(p => p.Leaf)
                .HasForeignKey(p => p.LeafId);
        }
    }
}

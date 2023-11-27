using System.ComponentModel.DataAnnotations;

namespace PlantApp.Models
{
    public class Genus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Plant> Plants { get; } = new List<Plant>();
    }
}

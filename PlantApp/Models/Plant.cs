using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PlantApp.Models
{
    public class Plant
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenusId { get; set; }
        public int SoilId { get; set; }
        public int LeafId { get; set; }

        // Navigation properties
        [JsonIgnore]
        [ForeignKey("GenusId")]
        public Genus Genus { get; set; }

        [JsonIgnore]
        [ForeignKey("SoilId")]
        public Soil Soil { get; set; }

        [JsonIgnore]
        [ForeignKey("LeafId")]
        public Leaf Leaf { get; set; }
    }
}

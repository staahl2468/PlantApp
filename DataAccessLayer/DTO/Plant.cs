using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    internal class Plant
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

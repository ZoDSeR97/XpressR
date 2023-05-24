using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class Amenity
    {
        [Key]
        public int AmenityId { get; set; }

        [Required]
        public string? Name { get; set; }
        
        // Navigation Property
        public List<HasAmenities> Properties { get; set; } = new List<HasAmenities>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class HasAmenities
    {
        [Key]
        public int HasAmenitiesId { get; set; }
        
        public int AmenityId { get; set; }
        
        public int PropertyId { get; set; }

        public Amenity? Amenity { get; set; }
        public Property? Property { get; set; }
    }
}

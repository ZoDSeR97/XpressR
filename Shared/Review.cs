using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class Review
    {
        [Key, ForeignKey("RSVPId")]
        public int ReviewId { get; set; }

        public int RSVPId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required]
        [Range(0,5)]
        public float Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Navigation Property
        public RSVP? PastTrip { get; set; }
    }
}

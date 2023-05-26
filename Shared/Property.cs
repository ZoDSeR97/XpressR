using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        public int UserId { get; set; }

        [Required]
        [MinLength(2)]
        public string? Name { get; set; }

        [Required]
        [MinLength(5)]
        public string? Address { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string? Zip { get; set; }

        [Required]
        [MinLength(3)]
        public string? City { get; set; }

        [Required]
        [MinLength(5)]
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }

        public string? Thumbnail { get; set; }

        public string? Imgs { get; set; }

        public Boolean Room { get; set; } = false;

        public Boolean SharedRoom { get; set; } = false;

        //Navigation Property
        public User? Owner { get; set; }
        public List<RSVP> Guests { get; set; } = new List<RSVP>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
    }
}

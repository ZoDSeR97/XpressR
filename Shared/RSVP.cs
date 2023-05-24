using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class RSVP
    {
        [Key]
        public int RSVPId { get; set; }

        public int UserId { get; set;}

        public int PropertyId { get; set; }
        
        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        public Boolean IsChecked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Navigation Properties
        public User? Guest { get; set; }
        public Property? Property { get; set; }
        public Review? Review { get; set; }

    }
}

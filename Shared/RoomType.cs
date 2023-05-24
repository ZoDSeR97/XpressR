using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        //Navigation Property
        public List<HasTypes> Properties { get; set; } = new List<HasTypes>();
    }
}

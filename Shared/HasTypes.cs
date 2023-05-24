using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressR.Shared
{
    public class HasTypes
    {
        [Key]
        public int HasTypesId { get; set; }
        
        public int RoomTypeId { get; set; }
        
        public int PropertyId {get; set; }

        public RoomType? RoomType { get; set; }
        public Property? Property { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Polygons")]
    public class Polygon : BaseEntity
    {
     
        public int? Id { get; set; }
        public int PolygonNo { get; set; }
        public Decimal StartX { get; set; }
        public Decimal StartY { get; set; }
        public Decimal EndX { get; set; }
        public Decimal EndY { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<LineSegment> LineSegments { get; set; }
        public int? LabelId { get; set; }

        [ForeignKey("Photos")]
        public int PhotoId { get; set; }       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Polygons")]
    public class Polygon
    {
        public Polygon()
        {
            this.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy H:mm:ss"));
        }

        public int? Id { get; set; }
        public int PolygonNo { get; set; }
        public Decimal StartX { get; set; }
        public Decimal StartY { get; set; }
        public Decimal EndX { get; set; }
        public Decimal EndY { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public ICollection<LineSegment> LineSegments { get; set; }

        [ForeignKey("Photos")]
        public int PhotoId { get; set; }
    }
}

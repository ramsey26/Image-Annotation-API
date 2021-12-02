using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("LineSegments")]
    public class LineSegment
    {
       public LineSegment()
        {
            this.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy H:mm:ss"));
        }

        public int? Id { get; set; }
        public int PolygonNo { get; set; }
        public decimal X1 { get; set; }
        public decimal Y1 { get; set; }
        public decimal X2 { get; set; }
        public decimal Y2 { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("Polygons")]
        public int PolygonId { get; set; }
    }
}
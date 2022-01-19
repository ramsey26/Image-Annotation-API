using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("LineSegments")]
    public class LineSegment : BaseEntity
    {
        public int? Id { get; set; }
        public int PolygonNo { get; set; }
        public decimal X1 { get; set; }
        public decimal Y1 { get; set; }
        public decimal X2 { get; set; }
        public decimal Y2 { get; set; }
        [ForeignKey("Polygons")]
        public int PolygonId { get; set; }
    }
}
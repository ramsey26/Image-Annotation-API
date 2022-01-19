using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("BoundingBox")]
    public class BoundingBox : BaseEntity
    { 
        public int? Id { get; set; }
        public decimal X1 { get; set; }
        public decimal Y1 { get; set; }
        public decimal X2 { get; set; }
        public decimal Y2 { get; set; }
        public double Angle { get; set; }
        public int BoundingBoxNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public int? LabelId { get; set; }

        [ForeignKey("Photos")]
        public int PhotoId { get; set; }
    }
}

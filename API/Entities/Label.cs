using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Labels")]
    public class Label : BaseEntity
    {
        public int Id { get; set; }
        public string LabelName { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; } = true;
     
        [ForeignKey("UserProjects")]
        public int UserProjectId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("UserProjects")]
    public class UserProject:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Label> Labels { get; set; }

        [ForeignKey("User")]
        public int AppUserId { get; set; }
    }
}

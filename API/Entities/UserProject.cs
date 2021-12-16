using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("UserProjects")]
    public class UserProject
    {
        public UserProject()
        {
            this.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy H:mm:ss"));
        }

        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }       
        public ICollection<Photo> Photos { get; set; }

        [ForeignKey("User")]
        public int AppUserId { get; set; }
    }
}

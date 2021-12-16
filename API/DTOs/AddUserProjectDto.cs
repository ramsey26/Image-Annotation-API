using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AddUserProjectDto
    {
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}

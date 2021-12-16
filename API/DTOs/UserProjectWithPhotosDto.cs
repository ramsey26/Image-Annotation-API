using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserProjectWithPhotosDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LabelDto
    {
        public int Id { get; set; }
        public string LabelName { get; set; }
        public string Color { get; set; }
        public int UserProjectId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

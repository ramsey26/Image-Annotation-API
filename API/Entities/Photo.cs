using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo : BaseEntity
    {
     
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FileContent { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<BoundingBox> BoundingBoxes { get; set; }
        public ICollection<Polygon> Polygons { get; set; }

        [ForeignKey("UserProjects")]
        public int UserProjectId { get; set; }
    } 
}
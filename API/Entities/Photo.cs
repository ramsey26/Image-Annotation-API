using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public Photo()
        {
            this.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy H:mm:ss"));
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FileContent { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public ICollection<BoundingBox> BoundingBoxes { get; set; }
    } 
}
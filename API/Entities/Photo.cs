using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public Photo()
        {
            this.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FileContent { get; set; }
        public DateTime DateCreated { get; set; } 

    } 
}
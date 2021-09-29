using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    } 
}
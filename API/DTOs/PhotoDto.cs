using System.Collections.Generic;

namespace API.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FileContent { get; set; }
      //  public ICollection<BoundingBoxDto> BoundingBoxes { get; set; }
    }
}
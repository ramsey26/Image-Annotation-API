using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IPhotoRepository
    {
        void AddPhoto(Photo photo);
        Task<Photo> GetLastPhotoAsync(int projectId);
    } 
}

using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _dataContext;

        public PhotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddPhoto(Photo photo)
        {
            _dataContext.Photos.Add(photo);
        }

        public async Task<Photo> GetLastPhotoAsync(int projectId)
        {
            var userProject = await _dataContext.UserProjects
                .Include(x=>x.Photos)
                .SingleOrDefaultAsync(x=>x.Id== projectId);

            var lastPhoto = userProject.Photos.TakeLast<Photo>(1).FirstOrDefault();
            return lastPhoto;
        }
    }
}

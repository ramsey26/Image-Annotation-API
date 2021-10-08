using API.DTOs;
using API.Entities;
using API.Interfaces;
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

        public void InsertPhotoData(PhotoDto photoDto)
        {
            Photo photo = new Photo();
            photo.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            _dataContext.Photos.Add(photo);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}

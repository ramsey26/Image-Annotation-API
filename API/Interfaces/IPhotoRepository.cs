using API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    interface IPhotoRepository
    {
        Task<bool> SaveAllAsync();

        void InsertPhotoData(PhotoDto photoDto);
    }
}

using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
   public interface IBoundingBoxRepository
    {
        void Update(BoundingBox boundingBox);

        void Add(BoundingBox boundingBox);

        void Delete(BoundingBox boundingBox);

        Task<IEnumerable<BoundingBoxDto>> GetBoxByPhotoId(int photoId);

        Task<bool> SaveAllAsync();

    }
}

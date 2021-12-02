using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
   public interface IPolygonRepository
    {
        Task<Polygon> GetPolygonById(int id);
        void Add(Polygon polygon);
        void Update(Polygon polygon);
        void Delete(Polygon polygon);
        Task<IEnumerable<PolygonDto>> GetPolygonsByPhotoId(int photoId);
        Task<bool> SaveAllAsync();
    }
}

using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class PolygonRepository : IPolygonRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PolygonRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public void Add(Polygon polygon)
        {
            _dataContext.Polygons.Add(polygon);
        }
        public void Update(Polygon polygon)
        {
            _dataContext.Entry(polygon).State = EntityState.Modified;
        }

        public void Delete(Polygon polygon)
        {
            //polygon.IsActive = false;
            //Update(polygon);
            _dataContext.Polygons.Remove(polygon);
        }

        public async Task<IEnumerable<PolygonDto>> GetPolygonsByPhotoId(int photoId)
        {
            return await _dataContext.Polygons.Where(x => x.IsActive == true && x.PhotoId == photoId)
                .ProjectTo<PolygonDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Polygon> GetPolygonById(int id)
        {
            return await _dataContext.Polygons.Where(x => x.IsActive == true && x.Id == id)
                .Include(x=>x.LineSegments).FirstOrDefaultAsync();
        }
    }
}

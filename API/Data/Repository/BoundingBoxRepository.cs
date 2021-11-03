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
    public class BoundingBoxRepository : IBoundingBoxRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BoundingBoxRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public void Add(BoundingBox boundingBox)
        {
            _dataContext.BoundingBoxes.Add(boundingBox);
        }

        public void Delete(BoundingBox boundingBox)
        {
            boundingBox.IsActive = false;
            Update(boundingBox);
        }

        public void Update(BoundingBox boundingBox)
        {
            _dataContext.Entry(boundingBox).State = EntityState.Modified;
        }

        public async Task<IEnumerable<BoundingBoxDto>> GetBoxByPhotoId(int photoId)
        {
            return await _dataContext.BoundingBoxes.Where(x => x.PhotoId == photoId && x.IsActive==true)
                .ProjectTo<BoundingBoxDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

      
    }
}

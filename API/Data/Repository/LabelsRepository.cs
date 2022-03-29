using API.DTOs;
using API.Entities;
using API.Helpers;
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
    public class LabelsRepository : ILabelsRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public LabelsRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public void Add(Label label)
        {
            _dataContext.Labels.Add(label);
        }
        public void Update(Label label)
        {
            _dataContext.Entry(label).State = EntityState.Modified;
        }
        public void Delete(Label label)
        {
            label.IsActive = false;
            Update(label);
        }

        public async Task<IEnumerable<LabelDto>> GetLabelByUserProjectId(int userProjectId)
        {
            return await _dataContext.Labels.Where(x => x.UserProjectId == userProjectId && x.IsActive == true)
                .ProjectTo<LabelDto>(_mapper.ConfigurationProvider)
                 .ToListAsync();
        }

    }
}

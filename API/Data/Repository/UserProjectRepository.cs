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
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UserProjectRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public void AddUserProject(UserProject userProject)
        {
            _dataContext.UserProjects.Add(userProject);
        }

        public async Task<UserProjectWithPhotosDto> GetUserProjectByNameAsync(int userId, string projectName)
        {
            return await _dataContext.UserProjects
                 .Where(x => x.AppUserId == userId && x.ProjectName == projectName)
                 .ProjectTo<UserProjectWithPhotosDto>(_mapper.ConfigurationProvider)
                 .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserProjectWithPhotosDto>> GetUserProjectsAsync(int userId)
        {
            return await _dataContext.UserProjects
                .Where(x => x.AppUserId == userId && x.IsActive == true)
                .ProjectTo<UserProjectWithPhotosDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}

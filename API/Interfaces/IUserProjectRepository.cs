using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUserProjectRepository
    {
        void AddUserProject(UserProject userProject);
        void UpdateUserProject(UserProject userProject);
        Task<UserProject> GetUserProjectByIdAsync(int id);
        Task<UserProjectWithPhotosDto> GetUserProjectByNameAsync(int userId, string projectName);
        Task<IEnumerable<UserProjectWithPhotosDto>> GetUserProjectsAsync(int userId);
    }
}

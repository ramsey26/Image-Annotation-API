using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UserProjectsController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IMapper _mapper;

        public UserProjectsController(IUserRepository userRepository, IUserProjectRepository userProjectRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userProjectRepository = userProjectRepository;
            _mapper = mapper;
        }

        [HttpGet("{projectName}")]
        public async Task<ActionResult<UserProjectWithPhotosDto>> GetUserProjectByNameAsync(string projectName)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            return await _userProjectRepository.GetUserProjectByNameAsync(user.Id, projectName);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProjectWithPhotosDto>>> GetUserProjects()
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var userProjects = await _userProjectRepository.GetUserProjectsAsync(user.Id);
            return Ok(userProjects);
        }

        [HttpPost("add-project")]
        public async Task<ActionResult> CreateUserProject(AddUserProjectDto addUserProjectDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var mappedUserProject = _mapper.Map<UserProject>(addUserProjectDto);
            mappedUserProject.AppUserId = user.Id;

            //Check duplicate project name
            var existingUserProject = await _userProjectRepository.GetUserProjectByNameAsync(user.Id, addUserProjectDto.ProjectName);

            if (existingUserProject != null) return BadRequest("Project name already exists");

            //Add user project if project name is unique
            _userProjectRepository.AddUserProject(mappedUserProject);

            if (await _userProjectRepository.SaveAllAsync()) return Ok();

            return BadRequest("Error occured while adding new project.");
        }
    }
}

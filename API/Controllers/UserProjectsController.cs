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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public UserProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{projectName}")]
        public async Task<ActionResult<UserProjectWithPhotosDto>> GetUserProjectByNameAsync(string projectName)
        {
            var user = await this.unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            return await this.unitOfWork.UserProjectRepository.GetUserProjectByNameAsync(user.Id, projectName);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProjectWithPhotosDto>>> GetUserProjects()
        {
            var user = await this.unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            var userProjects = await this.unitOfWork.UserProjectRepository.GetUserProjectsAsync(user.Id);
            return Ok(userProjects);
        }

        [HttpPost("add-project")]
        public async Task<ActionResult> CreateUserProject(AddUserProjectDto addUserProjectDto)
        {
            var user = await this.unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            var mappedUserProject = _mapper.Map<UserProject>(addUserProjectDto);
            mappedUserProject.AppUserId = user.Id;

            //Check duplicate project name
            var existingUserProject = await this.unitOfWork.UserProjectRepository.GetUserProjectByNameAsync(user.Id, addUserProjectDto.ProjectName);

            if (existingUserProject != null) return BadRequest("Project name already exists");

            //Add user project if project name is unique
            this.unitOfWork.UserProjectRepository.AddUserProject(mappedUserProject);

            if (await this.unitOfWork.Complete()) return Ok();

            return BadRequest("Error occured while adding new project.");
        }

        [HttpPost("update-project")]
        public async Task<ActionResult> UpdateUserProject([FromBody]int userProjectId)
        {
            var userProject = await this.unitOfWork.UserProjectRepository.GetUserProjectByIdAsync(userProjectId);

            userProject.IsCompleted = userProject.IsCompleted != true;

            this.unitOfWork.UserProjectRepository.UpdateUserProject(userProject);

            if (await this.unitOfWork.Complete()) return Ok();
            return BadRequest("Error occured while updating project");
        }
    }
}

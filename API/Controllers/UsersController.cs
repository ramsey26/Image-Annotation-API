using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
       private readonly IUserRepository _userRepository;
        private readonly IBoundingBoxRepository _boundingBoxRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper, IBoundingBoxRepository boundingBoxRepository)
        {
            _userRepository = userRepository;
            _boundingBoxRepository = boundingBoxRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users);
        }

        //api/users/3
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
          return await _userRepository.GetMemberAsync(username);
          
        }

        [HttpPost("upload-photo")]
        public async Task<ActionResult> UploadPhotoData(PhotoDto photoDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            Photo photo = new Photo();

            _mapper.Map(photoDto, photo);

            user.Photos.Add(photo);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to upload photo.");
        }

        [HttpGet("getLastPhoto")]
        public async Task<ActionResult<Photo>> GetLastPhotoData()
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var lastPhoto = user.Photos.TakeLast<Photo>(1);

            return Ok(lastPhoto.FirstOrDefault());
        }

    }
}

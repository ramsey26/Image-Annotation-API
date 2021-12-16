using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class PhotoController : BaseApiController
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoRepository photoRepository,IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        [HttpPost("upload-photo/{projectId}")]
        public async Task<ActionResult> UploadPhotoData(int projectId, [FromBody] PhotoDto photoDto)
        {
            Photo photo = _mapper.Map<Photo>(photoDto);
            photo.UserProjectId = projectId;

            _photoRepository.AddPhoto(photo);

            if (await _photoRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to upload photo.");
        }

        [HttpGet("getLastPhoto/{projectId}")]
        public async Task<ActionResult<Photo>> GetLastPhotoData(int projectId)
        {
            var lastPhoto = await _photoRepository.GetLastPhotoAsync(projectId);

            return Ok(lastPhoto);
        }
    }
}

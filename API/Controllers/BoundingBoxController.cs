using API.DTOs;
using API.Entities;
using API.Helpers;
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
    public class BoundingBoxController : BaseApiController
    {
        
        private readonly IBoundingBoxRepository _boundingBoxRepository;
        private readonly IMapper _mapper;

        public BoundingBoxController(IBoundingBoxRepository boundingBoxRepository, IMapper mapper)
        {
            _boundingBoxRepository = boundingBoxRepository;
            _mapper = mapper;
        }

        [HttpPost("add-box")]
        public async Task<ActionResult> AddBoxes([FromBody]List<BoundingBoxDto> boundingBoxDtos)
        {
            IEnumerable<BoundingBox> boundingBoxes = new List<BoundingBox>();
            _mapper.Map(boundingBoxDtos, boundingBoxes);

            foreach(var box in boundingBoxes)
            {
                if (box.Id == null)
                {
                    _boundingBoxRepository.Add(box);
                }
            }
           
            if (await _boundingBoxRepository.SaveAllAsync()) return Ok();
            return BadRequest("Failed to add bounding box");
        }

        [HttpPost("save-box")]
        public async Task<ActionResult> SaveBoxByAction([FromBody]List<BoundingBoxDto> boundingBoxDtos)
        {
          
            foreach (var boxDto in boundingBoxDtos)
            {
                BoundingBox boundingBox = new BoundingBox();
                _mapper.Map(boxDto, boundingBox);
             
                switch (boxDto.Action)
                {
                    case EntityHelpers.actionAdd:
                        _boundingBoxRepository.Add(boundingBox);
                        break;
                    case EntityHelpers.actionEdit:
                        _boundingBoxRepository.Update(boundingBox);
                        break;
                    case EntityHelpers.actionDelete:
                         _boundingBoxRepository.Delete(boundingBox);
                        break;
                }
            }

            if (await _boundingBoxRepository.SaveAllAsync()) return Ok();
            return BadRequest("Failed to save bounding boxes");
        }

        [HttpGet("{photoId}")]
        public async Task<IEnumerable<BoundingBoxDto>> GetBoxByPhotoId(int photoId)
        {
            return await _boundingBoxRepository.GetBoxByPhotoId(photoId);
        }

    }
}

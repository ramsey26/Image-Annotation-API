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
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public BoundingBoxController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
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
                    this.unitOfWork.BoundingBoxRepository.Add(box);
                }
            }
           
            if (await this.unitOfWork.Complete()) return Ok();
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
                        this.unitOfWork.BoundingBoxRepository.Add(boundingBox);
                        break;
                    case EntityHelpers.actionEdit:
                        this.unitOfWork.BoundingBoxRepository.Update(boundingBox);
                        break;
                    case EntityHelpers.actionDelete:
                        this.unitOfWork.BoundingBoxRepository.Delete(boundingBox);
                        break;
                }
            }

            if (await this.unitOfWork.Complete()) return Ok();
            return BadRequest("Failed to save bounding boxes");
        }

        [HttpGet("{photoId}")]
        public async Task<IEnumerable<BoundingBoxDto>> GetBoxByPhotoId(int photoId)
        {
            return await this.unitOfWork.BoundingBoxRepository.GetBoxByPhotoId(photoId);
        }

    }
}

using API.Data.Repository;
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
    public class LabelsController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public LabelsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add-label")]
        public async Task<ActionResult> AddLabel([FromBody]LabelDto labelDto)
        {
            Label label = _mapper.Map<LabelDto, Label>(labelDto);
            
            this.unitOfWork.LabelsRepository.Add(label);
            if (await this.unitOfWork.Complete()) return Ok();
            return BadRequest("Failed to save label");
        }


        [HttpPost("update-label")]
        public async Task<ActionResult> UpdateLabel([FromBody] LabelDto labelDto)
        {
            Label label = _mapper.Map<LabelDto, Label>(labelDto);

            this.unitOfWork.LabelsRepository.Update(label);
            if (await this.unitOfWork.Complete()) return Ok();
            return BadRequest("Failed to update label");
        }

        [HttpPost("delete-label")]
        public async Task<ActionResult> DeleteLabel([FromBody] LabelDto labelDto)
        {
            Label label = _mapper.Map<LabelDto, Label>(labelDto);

            this.unitOfWork.LabelsRepository.Delete(label);

            //Also update Boundingboxes and Polygons if they contain deleted LabelId
            var listBoundingBox = await this.unitOfWork.BoundingBoxRepository.GetBoxByLabelId(label.Id);
            foreach (var box in listBoundingBox)
            {
                this.unitOfWork.BoundingBoxRepository.Delete(box);
            }

            var listPolygon = await this.unitOfWork.PolygonRepository.GetPolygonsByLabelId(label.Id);
            foreach (var polygon in listPolygon)
            {
                this.unitOfWork.PolygonRepository.Delete(polygon);
            }
            //await _boundingBoxRepository.SaveAllAsync();
            //await _polygonRepository.SaveAllAsync();

            if (await this.unitOfWork.Complete()) return Ok();
            return BadRequest("Failed to delete label");
        }

        [HttpGet("{userProjectId}")]
        public async Task<IEnumerable<LabelDto>> GetLabelsByUserProjectId(int userProjectId)
        {
            return await this.unitOfWork.LabelsRepository.GetLabelByUserProjectId(userProjectId);
        }
    }
}

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
        private readonly ILabelsRepository _labelsRepository;
        private readonly IBoundingBoxRepository _boundingBoxRepository;
        private readonly IPolygonRepository _polygonRepository;
        private readonly IMapper _mapper;

        public LabelsController(ILabelsRepository labelsRepository, IBoundingBoxRepository boundingBoxRepository,
            IPolygonRepository polygonRepository, IMapper mapper)
        {
            _labelsRepository = labelsRepository;
            _boundingBoxRepository = boundingBoxRepository;
            _polygonRepository = polygonRepository;
            _mapper = mapper;
        }

        [HttpPost("add-label")]
        public async Task<ActionResult> AddLabel([FromBody]LabelDto labelDto)
        {
            Label label = _mapper.Map<LabelDto, Label>(labelDto);
            
            _labelsRepository.Add(label);
            if (await _labelsRepository.SaveAllAsync()) return Ok();
            return BadRequest("Failed to save label");
        }


        [HttpPost("update-label")]
        public async Task<ActionResult> UpdateLabel([FromBody] LabelDto labelDto)
        {
            Label label = _mapper.Map<LabelDto, Label>(labelDto);

            _labelsRepository.Update(label);
            if (await _labelsRepository.SaveAllAsync()) return Ok();
            return BadRequest("Failed to update label");
        }

        [HttpPost("delete-label")]
        public async Task<ActionResult> DeleteLabel([FromBody] LabelDto labelDto)
        {
            Label label = _mapper.Map<LabelDto, Label>(labelDto);

            _labelsRepository.Delete(label);

            //Also update Boundingboxes and Polygons if they contain deleted LabelId
            var listBoundingBox = await _boundingBoxRepository.GetBoxByLabelId(label.Id);
            foreach (var box in listBoundingBox)
            {
                _boundingBoxRepository.Delete(box);
            }

            var listPolygon = await _polygonRepository.GetPolygonsByLabelId(label.Id);
            foreach (var polygon in listPolygon)
            {
                _polygonRepository.Delete(polygon);
            }
            //await _boundingBoxRepository.SaveAllAsync();
            //await _polygonRepository.SaveAllAsync();

            if (await _labelsRepository.SaveAllAsync()) return Ok();
            return BadRequest("Failed to delete label");
        }

        [HttpGet("{userProjectId}")]
        public async Task<IEnumerable<LabelDto>> GetLabelsByUserProjectId(int userProjectId)
        {
            return await _labelsRepository.GetLabelByUserProjectId(userProjectId);
        }
    }
}

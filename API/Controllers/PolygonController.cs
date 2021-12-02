using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PolygonController : BaseApiController
    {
        private readonly IPolygonRepository _polygonRepository;
        private readonly IMapper _mapper;

        public PolygonController(IPolygonRepository polygonRepository, IMapper mapper )
        {
            _polygonRepository = polygonRepository;
            _mapper = mapper;
        }

        [HttpPost("save-polygon")]
        public async Task<ActionResult> SavePolygonByAction([FromBody]List<PolygonDto> polygonDtos)
        {
            foreach(var polygonDto in polygonDtos)
            {
                Polygon polygon = new Polygon();
               
                switch (polygonDto.Action)
                {
                    case ActionConstants.actionAdd:
                        _mapper.Map(polygonDto, polygon);
                        _polygonRepository.Add(polygon);
                        break;
                    case ActionConstants.actionDelete:
                        polygon = await _polygonRepository.GetPolygonById((int)polygonDto.Id);
                        _polygonRepository.Delete(polygon);
                        break;
                }
            }

            if (await _polygonRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to save polygons");
        }

        [HttpGet("{photoId}")]
        public async Task<IEnumerable<PolygonDto>> GetPolygonsByPhotoId(int photoId)
        {
            return await _polygonRepository.GetPolygonsByPhotoId(photoId);
        }
    }
}

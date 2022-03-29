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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public PolygonController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
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
                    case EntityHelpers.actionAdd:
                        _mapper.Map(polygonDto, polygon);
                        this.unitOfWork.PolygonRepository.Add(polygon);
                        break;
                    case EntityHelpers.actionEdit:
                        _mapper.Map(polygonDto, polygon);
                        this.unitOfWork.PolygonRepository.Update(polygon);
                        break;
                    case EntityHelpers.actionDelete:
                        polygon = await this.unitOfWork.PolygonRepository.GetPolygonById((int)polygonDto.Id);
                        this.unitOfWork.PolygonRepository.Delete(polygon);
                        break;
                }
            }

            if (await this.unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to save polygons");
        }

        [HttpGet("{photoId}")]
        public async Task<IEnumerable<PolygonDto>> GetPolygonsByPhotoId(int photoId)
        {
            return await this.unitOfWork.PolygonRepository.GetPolygonsByPhotoId(photoId);
        }
    }
}

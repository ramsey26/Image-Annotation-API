﻿using API.DTOs;
using API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Where(x => x.IsActive == true)));
            CreateMap<MemberDto, AppUser>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();
            CreateMap<BoundingBox, BoundingBoxDto>();
            CreateMap<BoundingBoxDto, BoundingBox>();
            CreateMap<IEnumerable<BoundingBoxDto>, MemberDto>();
        }
    }
}

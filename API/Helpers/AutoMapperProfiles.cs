using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()  
                .ForMember(dest => dest.PhotoUrl // destination, our target
                           , opt => opt.MapFrom(src =>src.Photos.FirstOrDefault(x => x.IsMain).Url)) // map from there to our target
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge())); // from calculateAge method to age field of dto
            CreateMap<Photo, PhotoDto>();
        }
    }
}
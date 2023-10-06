using API.Dtos;
using AutoMapper;
using Core;

namespace API.Profiles;



public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        /* CreateMap<Area,AreaDto>()
        .ReverseMap()
        .ForMember(o => o.Lugares, d => d.Ignore()); */

        //CreateMap<Area,AreaxLugarDto>().ReverseMap();
    }
}
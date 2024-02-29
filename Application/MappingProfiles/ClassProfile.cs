using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Class, ClassViewDto>().ReverseMap();
        }
    }
}
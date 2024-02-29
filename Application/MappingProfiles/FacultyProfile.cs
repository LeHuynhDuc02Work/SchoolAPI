using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class FacultyProfile : Profile
    {
        public FacultyProfile()
        {
            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<Faculty, FacultyViewDto>().ReverseMap();
        }
    }
}
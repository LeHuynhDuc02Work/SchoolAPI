using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, SubjectViewDto>().ReverseMap();
        }
    }
}
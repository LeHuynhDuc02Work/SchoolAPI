using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentViewDto>().ReverseMap();
        }
    }
}
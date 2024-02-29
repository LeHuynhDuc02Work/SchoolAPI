using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.MappingProfiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultDto>().ReverseMap();
            CreateMap<Result, ResultViewDto>().ReverseMap();
        }
    }
}
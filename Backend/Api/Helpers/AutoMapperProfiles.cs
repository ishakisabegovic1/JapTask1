using Api.DTOs;
using Api.Entities;
using AutoMapper;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Selection, SelectionDto>().
                ForMember(dest=>dest.Jap, opt=> opt.MapFrom(src=>src.Jap.Name));
            CreateMap<SelectionDto, Selection>();
        }

    }
}

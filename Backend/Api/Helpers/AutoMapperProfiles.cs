using Api.DTOs;
using Api.Entities;
using AutoMapper;

namespace Api.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<ProgramDto, Program>();

      CreateMap<Student, StudentDto>()
          .ForMember(dest => dest.Selection, src => src.MapFrom(m => m.Selection.Name));

      CreateMap<StudentDto, Student>().ForMember(dest => dest.Selection, src => src.MapFrom(x => 0));

      CreateMap<Selection, SelectionDto>()
          .ForMember(dest => dest.Jap, opt => opt.MapFrom(src => src.Jap.Name));
      CreateMap<SelectionDto, Selection>()
        .ForMember(dest => dest.Jap, opt => opt.MapFrom(src => 0));

      CreateMap<Comment, CommentDto>();

      CreateMap<CommentDto, Comment>();



      CreateMap<SelectionDto, Selection>();
    }

  }
}

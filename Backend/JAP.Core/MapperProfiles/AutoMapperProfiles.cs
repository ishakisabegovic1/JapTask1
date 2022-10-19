

using AutoMapper;


namespace JAP.Core.MapperProfiles
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<ProgramDto, Program>();

      CreateMap<Student, StudentDto>()
          .ForMember(dest => dest.Selection, src => src.MapFrom(m => m.Selection.Name));

      CreateMap<StudentDto, Student>().ForMember(dest => dest.Selection, src => src.MapFrom(x => ""));

      CreateMap<StudentUpdateDto, Student>();
      CreateMap<Student, StudentUpdateDto>();

      CreateMap<Selection, SelectionDto>()
          .ForMember(dest => dest.Jap, opt => opt.MapFrom(src => src.Program.Name));

      CreateMap<SelectionDto, Selection>()
        .ForMember(dest => dest.Program, opt => opt.MapFrom(src => 0));

      CreateMap<Comment, CommentDto>();

      CreateMap<CommentDto, Comment>();



      CreateMap<SelectionDto, Selection>();

      CreateMap<LoginDto, User>();
    }

  }
}

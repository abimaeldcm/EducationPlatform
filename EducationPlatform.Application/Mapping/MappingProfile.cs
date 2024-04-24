using AutoMapper;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.Users;

namespace EducationPlatform.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlockInput, Block>();
            CreateMap<Block, BlockOutput>();

            CreateMap<CourseInput, Course>();
            CreateMap<Course, CourseOutput>();

            CreateMap<LessonInput, Lesson>();
            CreateMap<Lesson, LessonOutput>();

            CreateMap<SignatureInput, Signature>();
            CreateMap<Signature, SignatureOutput>();

            CreateMap<UserInput, UserEntity>();
            CreateMap<UserEntity, UserOutput>();            
        }
    }
}

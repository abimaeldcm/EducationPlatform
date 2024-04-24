using EducationPlatform.Application.Interface;
using EducationPlatform.Application.Service;
using EducationPlatform.Application.Services;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.EntityRelational;
using EducationPlatform.Domain.Entity.Users;
using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace EducationPlatform.Infra.IoC
{
    public static class Injections
    {
        public static IServiceCollection AddInjections(this IServiceCollection services,
                      IConfiguration Configuration)
        {            
            //
            services.AddScoped<ICRUDService<BlockOutput,BlockInput>, BlockService>();
            services.AddScoped<ICRUDRepository<Block>, BlockRepository>();
            
            //
            services.AddScoped<ICRUDService<CourseOutput, CourseInput>, CourseService>();
            services.AddScoped<ICRUDRepository<Course>, CourseRepository>();

            //
            services.AddScoped<ICRUDService<LessonOutput, LessonInput>, LessonService>();
            services.AddScoped<ICRUDRepository<Lesson>, LessonRepository>();

            //
            services.AddScoped<ICRUDService<SignatureOutput, SignatureInput>, SignatureService>();
            services.AddScoped<ICRUDRepository<Signature>, SignatureRepository>();

            //
            services.AddScoped<ICRUDService<UserOutput, UserInput>, UserService>();
            services.AddScoped<ICRUDRepository<UserEntity>, UserEntityRepository>();        
            
            services.AddScoped<IUserSignatureRepository, UserSignatureRepository>();
            services.AddScoped<ICRUDRepository<UserSignature>, UserSignatureRepository>();
            
            //
            services.AddScoped<ICRUDService<UserOutput, UserInput>, UserService>();
            services.AddScoped<ICRUDRepository<UserEntity>, UserEntityRepository>();
            services.AddScoped<ILoginService, UserService>();
            services.AddScoped<ILoginRepository, UserEntityRepository>();

            services.AddSingleton<ClaimsPrincipal>();

            return services;
        }
    }
}

using EducationPlatform.Application.Interface;
using EducationPlatform.Application.Service;
using EducationPlatform.Application.Services;
using EducationPlatform.Domain.Entity;
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
            //Atendimento
            services.AddScoped<ICRUDService<BlockOutput,BlockInput>, BlockService>();
            services.AddScoped<ICRUDRepository<Block>, BlockRepository>();
            
            //Espacialidade
            services.AddScoped<ICRUDService<CourseOutput, CourseInput>, CourseService>();
            services.AddScoped<ICRUDRepository<Course>, CourseRepository>();

            //Médico
            services.AddScoped<ICRUDService<LessonOutput, LessonInput>, LessonService>();
            services.AddScoped<ICRUDRepository<Lesson>, LessonRepository>();

            //Paciente
            services.AddScoped<ICRUDService<SignatureOutput, SignatureInput>, SignatureService>();
            services.AddScoped<ICRUDRepository<Signature>, SignatureRepository>();

            //Servico
            services.AddScoped<ICRUDService<UserOutput, UserInput>, UserService>();
            services.AddScoped<ICRUDRepository<UserEntity>, UserEntityRepository>();           
            
            //User
            services.AddScoped<ICRUDService<UserOutput, UserInput>, UserService>();
            services.AddScoped<ICRUDRepository<UserEntity>, UserEntityRepository>();
            services.AddScoped<ILoginService, UserService>();
            services.AddScoped<ILoginRepository, UserEntityRepository>();

            services.AddScoped<ClaimsPrincipal>();

            return services;
        }
    }
}

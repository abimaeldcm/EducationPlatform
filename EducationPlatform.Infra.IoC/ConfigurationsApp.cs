using EducationPlatform.Application.Mapping;
using EducationPlatform.Application.Services.WorkService;
using EducationPlatform.Application.Validations;
using EducationPlatform.Infra.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPlatform.Infra.IoC
{
    public static class ConfigurationsApp
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                      IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddDbContext<EducationDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("DataBase"),
                    b => b.MigrationsAssembly(typeof(EducationDbContext).Assembly.FullName)));

            
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BlockValidation>());

            services.AddHostedService<Worker>();

            return services;

        }
    }
}

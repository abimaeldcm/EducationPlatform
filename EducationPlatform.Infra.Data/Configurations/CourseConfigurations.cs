using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.HasMany(x => x.Block)
                   .WithOne(b => b.Course);

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "Introdução o C#",
                    Description = "Iniciando pelo básico do C#",
                    Cover = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.treinaweb.com.br%2Fblog%2Fcomo-instalar-o-csharp-e-nosso-primeiro-exemplo&psig=AOvVaw1j2JR7fNFScafseX_uX4qA&ust=1713292306049000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCPDhk67txIUDFQAAAAAdAAAAABAE",
                    CreationDate = DateTime.Now,
                    SignatureId = 1,
                });
        }
    }

}

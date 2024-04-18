using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.HasData(
                new Lesson
                {
                    Id = 1,
                    Name = "Visual Studio Code",
                    Description = "Descrição",
                    LinkVideo = "https://www.youtube.com/watch?v=PZ7HiQdT0Dw",
                    Duration = 600,
                    CreationDate = DateTime.Now,
                    BlockId = 1                    
                });
        }
    }
}

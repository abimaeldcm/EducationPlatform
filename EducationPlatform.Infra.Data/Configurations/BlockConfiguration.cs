using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.HasOne(x => x.Course)
                   .WithMany(x => x.Block)
                   .OnDelete(DeleteBehavior.Cascade); // Excluir blocos se o curso for excluído

            builder.HasMany(x => x.Lesson)
                .WithOne(x => x.Block)
                .HasForeignKey(x => x.IdBlock)
                .OnDelete(DeleteBehavior.Cascade); ;

        }
    }
}

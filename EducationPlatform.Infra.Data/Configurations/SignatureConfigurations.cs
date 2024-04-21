using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class SignatureConfiguration : IEntityTypeConfiguration<Signature>
    {
        public void Configure(EntityTypeBuilder<Signature> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasData(
                new Signature
                {
                    Id = 1,
                    Name = "Padrão",
                    Duration = 365,
                    IsActive = true,
                }
                );
        }
    }
}

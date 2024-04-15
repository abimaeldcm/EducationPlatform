using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CPF)
                   .IsRequired()
                   .HasMaxLength(14);

            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(20);

            builder.HasMany(us => us.Courses)
                   .WithOne()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}

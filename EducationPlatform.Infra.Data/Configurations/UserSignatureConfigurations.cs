using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity.EntityRelational;

namespace Consultorio.Infra.Data.Configurations
{
    public class UserSignatureConfiguration : IEntityTypeConfiguration<UserSignature>
    {
        public void Configure(EntityTypeBuilder<UserSignature> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(us => us.User)
                   .WithMany()
                   .HasForeignKey(us => us.IdUser)
                   .IsRequired();

            builder.HasOne(us => us.Signature)
                   .WithMany()
                   .HasForeignKey(us => us.IdSignature)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
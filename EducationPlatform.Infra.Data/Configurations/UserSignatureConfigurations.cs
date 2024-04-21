using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity.EntityRelational;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class UserSignatureConfiguration : IEntityTypeConfiguration<UserSignature>
    {
        public void Configure(EntityTypeBuilder<UserSignature> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(us => us.User)
                   .WithMany()
                    .HasForeignKey(ulc => ulc.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(us => us.Signature)
                   .WithMany()
                   .HasForeignKey(ulc => ulc.SignatureId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
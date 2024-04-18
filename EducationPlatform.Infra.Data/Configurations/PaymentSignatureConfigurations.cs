using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class PaymentSignatureConfiguration : IEntityTypeConfiguration<PaymentSignature>
    {
        public void Configure(EntityTypeBuilder<PaymentSignature> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserSignature)
                   .WithMany()
                   .HasForeignKey(x => x.IdUserSignature);

            builder.Property(x => x.Message)
                .HasMaxLength(200);
            builder.Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");
        }
    }
}

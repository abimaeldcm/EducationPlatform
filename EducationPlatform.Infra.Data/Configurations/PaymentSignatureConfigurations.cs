using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity;

namespace Consultorio.Infra.Data.Configurations
{
    public class PaymentSignatureConfiguration : IEntityTypeConfiguration<PaymentSignature>
    {
        public void Configure(EntityTypeBuilder<PaymentSignature> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Siganature)
                   .WithMany()
                   .HasForeignKey(x => x.IdSignature)
                   .OnDelete(DeleteBehavior.Cascade); 
                                                      
            builder.HasOne(x => x.UserSignature)
                   .WithMany()
                   .HasForeignKey(x => x.IdUserSignature)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.Property(x => x.Message)
                .HasMaxLength(200);     
        }
    }
}

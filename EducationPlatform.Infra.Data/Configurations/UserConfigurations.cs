using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
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

            builder.HasData(
                new UserEntity
                {
                    Id = 1,
                    FullName = "abi",
                    CPF = "06445661327",
                    Email = "abi@mail.com",
                    Birthday = new DateTime(1997, 04, 25),
                    AccessLevel = Domain.Entity.Enum.EAccessLevel.Manager,
                    IsActive = true,
                    PhoneNumber = "86952258855",
                    Password = "123456789"

                },
                new UserEntity
                {
                    Id = 2,
                    FullName = "nay",
                    CPF = "12345678910",
                    Email = "joao@mail.com",
                    Birthday = new DateTime(1985, 10, 15),
                    AccessLevel = Domain.Entity.Enum.EAccessLevel.Student,
                    IsActive = true,
                    PhoneNumber = "987654321",
                    Password = "123456789"
                }
                );

        }
    }
}

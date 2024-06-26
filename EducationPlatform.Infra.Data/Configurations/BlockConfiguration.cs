﻿using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlatform.Infra.Data.Configurations
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
                   .HasForeignKey(x => x.IdCourse);
            builder.HasData(
                new Block
                {
                    Id = 1,
                    Name = "Instalção das ferramentas",
                    Description = "Description",
                    CreationDate = DateTime.Now,
                    IdCourse = 1,
                });
        }
    }
}

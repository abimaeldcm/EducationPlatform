using EducationPlatform.Domain.Entity.EntityRelational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlatform.Infra.Data.Configurations
{
    public class UserLessonCompletedConfiguration : IEntityTypeConfiguration<UserLessonCompleted>
    {
        public void Configure(EntityTypeBuilder<UserLessonCompleted> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(ulc => ulc.User)
                   .WithMany()
                   .HasForeignKey(ulc => ulc.IdUser)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction); // Definindo a ação de exclusão como NoAction

            builder.HasOne(ulc => ulc.Lesson)
                   .WithMany()
                   .HasForeignKey(ulc => ulc.IdLesson)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction); // Definindo a ação de exclusão como NoAction


        }
    }
}

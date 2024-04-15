using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.EntityRelational;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Consultorio.Infra.Data
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Signature> Signature { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<PaymentSignature> PaymentSignatures { get; set; }

        //Relational
        public DbSet<UserSignature> UserSignatures { get; set; }
        public DbSet<UserLessonCompleted> UserLessonCompleted { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

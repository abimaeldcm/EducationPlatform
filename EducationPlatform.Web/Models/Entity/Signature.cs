namespace EducationPlatform.Web.Domain.Entity
{
    public class Signature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

namespace EducationPlatform.Domain.Entity
{
    public class BlockOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdCourse { get; set; }

        public Course Course { get; set; }
        public List<Lesson> Lesson { get; set; }
    }
}

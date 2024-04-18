namespace EducationPlatform.Domain.Entity
{
    public class LessonInput
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string LinkVideo { get; set; }
        public int Duration { get; set; }
        public int BlockId { get; set; }
    }
}

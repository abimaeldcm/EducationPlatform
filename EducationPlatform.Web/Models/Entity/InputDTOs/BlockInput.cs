namespace EducationPlatform.Web.Domain.Entity
{
    public class BlockInput
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdCourse { get; set; }
    }
}

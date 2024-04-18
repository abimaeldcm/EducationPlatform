using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity
{
    public class CourseInput
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Cover { get; set; } //Capa
        public DateTime CreationDate { get; set; }
        public EAccessLevel AccessLevel { get; set; }
    }
}

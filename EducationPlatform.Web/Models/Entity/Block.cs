using System.Text.Json.Serialization;

namespace EducationPlatform.Web.Domain.Entity
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdCourse { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }
        public List<Lesson> Lesson { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace EducationPlatform.Domain.Entity
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string LinkVideo { get; set; }
        public int Duration { get; set; }

        public int BlockId { get; set; }
        [JsonIgnore]
        public Block Block { get; set; }
    }
}

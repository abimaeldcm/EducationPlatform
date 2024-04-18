using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Cover { get; set; } //Capa
        public DateTime CreationDate { get; set; }
        public int SignatureId { get; set; }

        public Signature Signature { get; set; }
        public List<Block> Block { get; set; }
    }
}

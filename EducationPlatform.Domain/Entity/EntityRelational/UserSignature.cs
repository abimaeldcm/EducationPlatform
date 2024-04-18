using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity.EntityRelational
{
    public class UserSignature
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SignatureId { get; set; }
        public EStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public UserEntity User { get; set; }
        public Signature Signature { get; set; }
    }
}

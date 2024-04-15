using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity.EntityRelational
{
    public class UserSignature
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdSignature { get; set; }
        public EStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public User User { get; set; }
        public Signature Signature { get; set; }
    }
}

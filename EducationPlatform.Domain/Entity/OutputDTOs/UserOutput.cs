using EducationPlatform.Domain.Entity.EntityRelational;
using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity
{
    public class UserOutput
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public EAccessLevel AccessLevel { get; set; }
        public EProfile Profile { get; set; }
        public bool IsActive { get; set; }

        public int UserSignatureId { get; set; }
        public UserSignature UserSignature { get; set; }
    }
}

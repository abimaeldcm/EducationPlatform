using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity.Users
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public EAccessLevel AccessLevel { get; set; }
        public bool IsActive { get; set; }
    }
}

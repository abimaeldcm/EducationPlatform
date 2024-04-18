using EducationPlatform.Domain.Entity;

namespace EducationPlatform.Domain.Entity
{
    public class UserLogged
    {
        public UserOutput User { get; set; }
        public string Token {  get; set; }
    }
}

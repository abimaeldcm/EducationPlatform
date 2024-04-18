using EducationPlatform.Domain.Entity;

namespace EducationPlatform.Application.Interface
{
    public interface ILoginService
    {
        Task<UserOutput> FindLogin(string name, string password);
    }
}

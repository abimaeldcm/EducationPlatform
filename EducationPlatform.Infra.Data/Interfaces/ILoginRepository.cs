using EducationPlatform.Domain.Entity;

namespace Consultorio.Infra.Data.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> FindLogin(string name, string password);
    }
}

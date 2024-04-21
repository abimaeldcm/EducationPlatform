using EducationPlatform.Domain.Entity;

namespace EducationPlatform.Infra.Data.Interfaces
{
    public interface ILoginRepository
    {
        Task<UserEntity> FindLogin(string name, string password);
        Task<UserEntity> UpdatePassword(int id, string OldPassword, string newPassword);
    }
}

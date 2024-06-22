using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.AssasEntity;
using EducationPlatform.Domain.Entity.Users;

namespace EducationPlatform.Application.Services.Assas
{
    public interface IAPIAssas
    {
        Task<UserAssas> Create(UserEntity user);
    }
}

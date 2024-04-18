using EducationPlatform.Domain.Entity.EntityRelational;

namespace EducationPlatform.Infra.Data.Interfaces
{
    public interface IUserSignatureRepository
    {
        Task<UserSignature> FindByUser(int id);
    }
}

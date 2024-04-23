using EducationPlatform.Web.Domain.Entity;

namespace EducationPlatform.Web.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserLogged> FindLogin(Login user);
    }
}

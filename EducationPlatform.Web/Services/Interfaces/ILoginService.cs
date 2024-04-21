using EducationPlatform.Web.Domain.Entity;

namespace Consultorio.Web.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserLogged> FindLogin(Login user);
    }
}

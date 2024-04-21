using EducationPlatform.Web.Domain.Entity;

namespace EducationPlatform.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UserLogged usuario);
        void RemoverSessaoUsuario();
        UserLogged BuscarSessaoDoUsuario();
    }
}

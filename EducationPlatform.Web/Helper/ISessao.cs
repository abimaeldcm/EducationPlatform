using EducationPlatform.Web.Domain.Entity;

namespace EducationPlatform.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Login usuario);
        void RemoverSessaoUsuario();
        UserLogged BuscarSessaoDoUsuario();
    }
}

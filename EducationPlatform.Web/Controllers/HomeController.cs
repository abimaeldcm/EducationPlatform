using EducationPlatform.Web.Domain.Entity.Enum;
using EducationPlatform.Web.Filters;
using EducationPlatform.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ISessao sessao, IHttpContextAccessor httpContextAccessor)
        {
            _sessao = sessao;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var valor = _httpContextAccessor.HttpContext.Session.GetString("MinhaChave");

            return View();
        }

        public IActionResult Sair()
        {
            try
            {
                _sessao.RemoverSessaoUsuario();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos realizar o Logoff! Detalhes:" + erro.Message;
                return RedirectToAction("Index"); ;
            }

        }
    }
}

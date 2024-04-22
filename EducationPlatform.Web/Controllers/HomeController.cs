﻿using EducationPlatform.Web.Domain.Entity.Enum;
using EducationPlatform.Web.Filters;
using EducationPlatform.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ISessao _sessao;

        public HomeController(ISessao sessao)
        {
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            var UsuarioSessao = _sessao.BuscarSessaoDoUsuario();
            EAccessLevel Profille = UsuarioSessao.User.AccessLevel;
            return View(Profille);
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

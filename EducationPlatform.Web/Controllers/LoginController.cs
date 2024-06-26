﻿using Microsoft.AspNetCore.Mvc;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;

namespace EducationPlatform.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ISessao _session;

        public LoginController(ILoginService loginService, ISessao session)
        {
            _loginService = loginService;
            _session = session;
        }

        public IActionResult Index()
        {
            try
            {
                if (_session.BuscarSessaoDoUsuario() != null)
                {
                    TempData["MensagemSucesso"] = "Seja bem vindo! Você já está logado!";
                    return RedirectToAction("Index", "Home");
                }

                return View();

            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Logar(Login usuario)
        {
            try
            {
                UserLogged usuarioDB = await _loginService.FindLogin(usuario);
                if (usuarioDB != null)
                {
                    _session.CriarSessaoDoUsuario(usuarioDB);

                    if (usuarioDB.User.AccessLevel == Domain.Entity.Enum.EAccessLevel.Student)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Index", "HomeManager");
                }
                TempData["MensagemErro"] = "Login ou senha estão incorretos";

                return View("Index", usuarioDB);
            }
            catch (Exception msg)
            {
                TempData["MensagemErro"] = msg.Message;
                return View("Index");
            }
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UserInput usuario)
        {
            await _loginService.Create(usuario);
            return View();
        }

        public IActionResult EsqueciSenha()
        {
            return View("PrimeiroLogin");
        }

        public IActionResult PrimeiroLogin()
        {
            return View();

        }
        [HttpPost]
        public IActionResult PrimeiroLogin(string email)
        {/*
            var usuarioExiste = _loginService.BuscarPorEmail(email);
            if (usuarioExiste != null)
            {
                int codigo = _VerificadorDeCodigoService.GerarCodigo();

                _emailService.SendEmailAsync(email,
                    "Código de Recuperação",
                $"Seu código de recuperação é: {codigo} \n Código válido por 10 minutos.");

                _VerificadorDeCodigoService.GuardarEmailCache(email);

                TempData["MensagemSucessoEnvio"] = "Encaminhamos um código de recuperação para o seu e-mail";
                return RedirectToAction("ConfirmacaoCodigo");
            }
            else
            {
                TempData["MensagemEmailNaoEncontrado"] = "Não encontramos o e-mail informado. Verifique as informações ou entre em contato com o seu administrador.";
                return View("PrimeiroLogin");
            }*/
            return null;
        }
        public IActionResult ConfirmacaoCodigo()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ConfirmacaoCodigo(string codigo)
        {/*
            var codigoIgual = _VerificadorDeCodigoService.ValidarCodigoEnviado(codigo);

            if (codigoIgual)
            {
                return RedirectToAction("AlterarSenha");
            }

            TempData["CodigoIncorreto"] = "O código informado não corresponde ao enviado para o seu e-mail. Tente novamente.";
            */
            return View();
        }

        public IActionResult AlterarSenha()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AlterarSenha(string NovaSenha, string ConfirmarNovaSenha)
        {/*
            if (NovaSenha != ConfirmarNovaSenha)
            {
                ModelState.AddModelError("ConfirmarNovaSenha", "As senhas não correspondem.");
                return View();
            }

            var email = _VerificadorDeCodigoService.RecuperarEmailCache();

            if (email == null)
            {
                //colocar a excessão aqui
                return View();
            }

            User Usuario = _loginService.BuscarPorEmail(email);
            Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(NovaSenha);

            _loginService.AlterarSenha(Usuario);

            TempData["SenhaAlterada"] = "Sua senha foi alterada com sucesso!";
            */
            return RedirectToAction("Index", "Login");
        }
    }
}

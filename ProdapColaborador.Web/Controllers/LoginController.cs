using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProdapColaborador.Business.Interfaces.Servicos;
using System;

namespace ProdapColaborador.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioServico _usuarioServico;

        public LoginController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(IFormCollection form)
        {
            try
            {
                var usuario = _usuarioServico.Logar(form["login"], form["senha"]);
                if (usuario != null)
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["alert"] = true;
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (DbUpdateException e)
            {
                throw;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

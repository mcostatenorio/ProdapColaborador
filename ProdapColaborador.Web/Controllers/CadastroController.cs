using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProdapColaborador.Business.Interfaces.Servicos;
using System;

namespace ProdapColaborador.Web.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IUsuarioServico _usuarioServico;

        public CadastroController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form)
        {
            try
            {
                var usuario = _usuarioServico.Cadastrar(form["login"], form["senha"]);
                if (usuario != null)
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["alert"] = true;
                    return RedirectToAction("Index", "Cadastro");
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

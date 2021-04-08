using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
                if(_usuarioServico.Logar(form["login"], form["senha"]))
                {
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

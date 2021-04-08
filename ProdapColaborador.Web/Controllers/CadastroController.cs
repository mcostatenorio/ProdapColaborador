using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Service.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if (_usuarioServico.Cadastrar(form["login"], form["senha"]))
                {
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

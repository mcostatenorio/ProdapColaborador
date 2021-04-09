using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Business.Modelos;
using ProdapColaborador.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProdapColaborador.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITarefaServico _tarefaServico;
        private static Usuario _usuario;

        public HomeController(ILogger<HomeController> logger,
                                    ITarefaServico tarefaServico)
        {
            _logger = logger;
            _tarefaServico = tarefaServico;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("SessionUser") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _usuario = JsonConvert.DeserializeObject<Usuario>
               (HttpContext.Session.GetString("SessionUser"));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CadastrarTarefa(IFormCollection form)
        {
            try
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Descricao = form["descricaoTarefa"];
                tarefa.IdUsuarioResponsavel = _usuario.Id;
                tarefa.Status = "Aberta";

                _tarefaServico.Adicionar(tarefa);
                return RedirectToAction("Index", "Home");
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

        [HttpPost]
        public JsonResult RemoverTarefa(int id)
        {
            _tarefaServico.Remover(id);
            return Json(new { data = 1 });
        }

        [HttpPost]
        public JsonResult AtualizarTarefa(int id, string descricao)
        {
            Tarefa tarefa = _tarefaServico.ObterPorId(id);
            tarefa.Descricao = descricao;
            _tarefaServico.Atualizar(tarefa);
            return Json(new { data = 1 });
        }

        [HttpPost]
        public JsonResult ConcluirTarefa(int id)
        {
            _tarefaServico.ConcluirTarefa(id);
            return Json(new { data = 1 });
        }

        [HttpGet]
        public JsonResult GetTarefasAbertas()
        {
            try
            {
                List<Tarefa> tarefasAbertas = _tarefaServico.ObterTarefasAbertasPorIdUsuario(_usuario.Id);
                return Json(new { _listaTarefasAbertas = tarefasAbertas });
            }
            catch (DbUpdateConcurrencyException ex2)
            {
                throw ex2;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public JsonResult GetTarefasConcluidas()
        {
            try
            {
                List<Tarefa> tarefasConcluidas = _tarefaServico.ObterTarefasConcluidasPorIdUsuario(_usuario.Id);
                return Json(new { _listaTarefasConcluidas = tarefasConcluidas });
            }
            catch (DbUpdateConcurrencyException ex2)
            {
                throw ex2;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public JsonResult GetTarefa(int id)
        {
            try
            {
                Tarefa tarefa = _tarefaServico.ObterPorId(id);
                return Json(new { _tarefa = tarefa });
            }
            catch (DbUpdateConcurrencyException ex2)
            {
                throw ex2;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

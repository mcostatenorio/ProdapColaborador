using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Business.Modelos;
using System.Collections.Generic;

namespace ProdapColaborador.Service.Servicos
{
    public class TarefaServico : ServicoBase<Tarefa>, ITarefaServico
    {
        protected readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaServico(ITarefaRepositorio tarefaRepositorio) : base(tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public List<Tarefa> ObterTarefasAbertasPorIdUsuario(int idUser)
        {
            return _tarefaRepositorio.ObterTarefasAbertasPorIdUsuario(idUser);
        }

        public List<Tarefa> ObterTarefasConcluidasPorIdUsuario(int idUser)
        {
            return _tarefaRepositorio.ObterTarefasConcluidasPorIdUsuario(idUser);
        }

        public void ConcluirTarefa(int idTarefa)
        {
            Tarefa tarefa = _repositorio.ObterPorId(idTarefa);
            tarefa.Status = "Concluida";
            _repositorio.Atualizar(tarefa);
        }
    }
}

using ProdapColaborador.Business.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdapColaborador.Business.Interfaces.Servicos
{
    public interface ITarefaServico : IServico<Tarefa>, IDisposable
    {
        List<Tarefa> ObterTarefasAbertasPorIdUsuario(int idUser);

        List<Tarefa> ObterTarefasConcluidasPorIdUsuario(int idUser);

        void ConcluirTarefa(int idTarefa);
    }
}

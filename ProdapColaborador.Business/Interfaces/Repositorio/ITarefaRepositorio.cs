using ProdapColaborador.Business.Modelos;
using System.Collections.Generic;

namespace ProdapColaborador.Business.Interfaces.Repositorio
{
    public interface ITarefaRepositorio : IRepositorio<Tarefa>
    {
        List<Tarefa> ObterTarefasAbertasPorIdUsuario(int IdUser);

        List<Tarefa> ObterTarefasConcluidasPorIdUsuario(int IdUser);
    }
}

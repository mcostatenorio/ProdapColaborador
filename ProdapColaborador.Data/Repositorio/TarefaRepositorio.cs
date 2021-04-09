using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Modelos;
using ProdapColaborador.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace ProdapColaborador.Data.Repositorio
{
    public class TarefaRepositorio : Repositorio<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(ProdapColaboradorDbContext context) : base(context) { }

        public List<Tarefa> ObterTarefasAbertasPorIdUsuario(int IdUser)
        {
            return DbSet.Where(a => a.IdUsuarioResponsavel == IdUser && a.Status == "Aberta").OrderBy(x=> x.DataCriacao).ToList();
        }

        public List<Tarefa> ObterTarefasConcluidasPorIdUsuario(int IdUser)
        {
            return DbSet.Where(a => a.IdUsuarioResponsavel == IdUser && a.Status == "Concluida").OrderBy(x => x.DataCriacao).ToList();
        }
    }
}

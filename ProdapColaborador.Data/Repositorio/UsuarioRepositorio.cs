using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Modelos;
using ProdapColaborador.Data.Context;
using System.Linq;

namespace ProdapColaborador.Data.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ProdapColaboradorDbContext context) : base(context) { }

        public Usuario ObterPorLogin(string login)
        {
            return DbSet.Where(a=> a.Login == login).FirstOrDefault();
        }
    }
}

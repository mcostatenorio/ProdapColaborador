using ProdapColaborador.Business.Modelos;

namespace ProdapColaborador.Business.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ObterPorLogin(string login);
    }
}

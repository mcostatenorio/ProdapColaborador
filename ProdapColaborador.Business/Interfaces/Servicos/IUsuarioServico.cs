using ProdapColaborador.Business.Modelos;
using System;

namespace ProdapColaborador.Business.Interfaces.Servicos
{
    public interface IUsuarioServico :IServico<Usuario>, IDisposable
    {
        Usuario Logar(string login, string senha);

        Usuario Cadastrar(string login, string senha);
    }
}

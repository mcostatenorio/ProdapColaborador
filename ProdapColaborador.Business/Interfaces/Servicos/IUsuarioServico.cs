using ProdapColaborador.Business.Modelos;
using System;

namespace ProdapColaborador.Business.Interfaces.Servicos
{
    public interface IUsuarioServico :IServico<Usuario>, IDisposable
    {
        bool Logar(string login, string senha);

        bool Cadastrar(string login, string senha);
    }
}

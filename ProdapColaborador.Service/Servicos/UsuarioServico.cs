using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Business.Modelos;

namespace ProdapColaborador.Service.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        protected readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool Cadastrar(string login, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorLogin(login);

            if (usuario != null)
            {
                return false;
            }

            Usuario user = new Usuario();
            user.Login = login;
            user.Senha = senha;
            _usuarioRepositorio.Adicionar(user);

            return true;
        }

        public bool Logar(string login, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorLogin(login);

            if(usuario == null)
            {
                return false;
            }

            if(usuario.Senha == senha)
            {
                return true;
            }

            return false;
        }
    }
}

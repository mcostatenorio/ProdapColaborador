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

        public Usuario Cadastrar(string login, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorLogin(login);

            if (usuario != null)
            {
                return null;
            }

            Usuario user = new Usuario();
            user.Login = login;
            user.Senha = senha;
            _usuarioRepositorio.Adicionar(user);

            return user;
        }

        public Usuario Logar(string login, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorLogin(login);

            if(usuario == null)
            {
                return null;
            }

            if(usuario.Senha == senha)
            {
                return usuario;
            }

            return null;
        }
    }
}

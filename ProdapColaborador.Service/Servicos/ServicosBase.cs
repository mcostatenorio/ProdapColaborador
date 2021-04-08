using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Interfaces.Servicos;
using ProdapColaborador.Business.Modelos;
using System.Collections.Generic;

namespace ProdapColaborador.Service.Servicos
{
    public abstract class ServicoBase<TEntity> : IServico<TEntity> where TEntity : EntitadeBase
    {
        public readonly IRepositorio<TEntity> _repositorio;

        protected ServicoBase(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual TEntity Adicionar(TEntity entitade)
        {
            return _repositorio.Adicionar(entitade);
        }

        public virtual TEntity Atualizar(TEntity entitade)
        {
            return _repositorio.Atualizar(entitade);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public virtual List<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public virtual void Remover(int id)
        {
            _repositorio.Remover(id);
        }
    }
}

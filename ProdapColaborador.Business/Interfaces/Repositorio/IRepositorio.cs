using ProdapColaborador.Business.Modelos;
using System;
using System.Collections.Generic;

namespace ProdapColaborador.Business.Interfaces.Repositorio
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : EntitadeBase
    {
        TEntity Adicionar(TEntity entidade);

        TEntity ObterPorId(int id);

        List<TEntity> ObterTodos();

        TEntity Atualizar(TEntity entidade);

        void Remover(int id);

        int SaveChanges();
    }
}

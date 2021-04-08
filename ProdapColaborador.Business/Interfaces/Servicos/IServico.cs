using ProdapColaborador.Business.Modelos;
using System;
using System.Collections.Generic;

namespace ProdapColaborador.Business.Interfaces.Servicos
{
    public interface IServico<TEntity> : IDisposable where TEntity : EntitadeBase
    {
        TEntity Adicionar(TEntity entity);

        TEntity ObterPorId(int id);

        List<TEntity> ObterTodos();

        TEntity Atualizar(TEntity entity);

        void Remover(int id);
    }
}

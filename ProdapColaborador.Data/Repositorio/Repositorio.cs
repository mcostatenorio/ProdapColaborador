using Microsoft.EntityFrameworkCore;
using ProdapColaborador.Business.Interfaces.Repositorio;
using ProdapColaborador.Business.Modelos;
using ProdapColaborador.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace ProdapColaborador.Data.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntitadeBase, new()
    {
        protected readonly ProdapColaboradorDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repositorio(ProdapColaboradorDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity entidade)
        {
            DbSet.Add(entidade);
            SaveChanges();
            return entidade;
        }

        public TEntity Atualizar(TEntity entidade)
        {
            DbSet.Update(entidade);
            SaveChanges();
            return entidade;
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(int id)
        {
            Db.Entry(ObterPorId(id)).State = EntityState.Detached;
            DbSet.Remove(new TEntity { Id = id });
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

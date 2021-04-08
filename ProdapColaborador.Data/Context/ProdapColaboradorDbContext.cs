using Microsoft.EntityFrameworkCore;
using ProdapColaborador.Business.Modelos;

namespace ProdapColaborador.Data.Context
{
    public class ProdapColaboradorDbContext : DbContext
    {
        public ProdapColaboradorDbContext(DbContextOptions<ProdapColaboradorDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

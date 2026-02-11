using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Infra.Data.Context
{

    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>();
            modelBuilder.Entity<Categoria>();
            modelBuilder.Entity<Transacao>();
        }



        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


    }
}

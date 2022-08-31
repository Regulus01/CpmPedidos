using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    // Classe responsável por gerenciar o trafego de dados
    // entre a aplicação e o banco de dados
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}

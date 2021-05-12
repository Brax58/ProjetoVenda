using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoProduto>()
                .HasOne(x => x.Pedido)
                .WithMany(e => e.Produtos)
                .HasForeignKey(f => f.PedidoId)
                .IsRequired();

            modelBuilder.Entity<PedidoProduto>()
                .Property(e => e.Id)
                .ValueGeneratedNever();
        }

    }
}

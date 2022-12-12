using Microsoft.EntityFrameworkCore;
using Pedidos.Bussines.Entities;

namespace Pedidos.Infraestruture.Data
{
    public class PedidoContext:DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pedido> PEDIDO { get; set; }
        public DbSet<ItensPedido> ITENS_PEDIDO { get;set; }
        public DbSet<Produto> PRODUTO { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECE.Pedido.Infra.Data
{
    public class PedidosContextFactory
        : IDesignTimeDbContextFactory<PedidosContext>
    {
        public PedidosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PedidosContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDB;Integrated Security=True;");

            return new PedidosContext(optionsBuilder.Options);
        }
    }
}

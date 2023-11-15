using ECE.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ACE.Clientes.API.Models;
using System.Threading.Tasks;

namespace ACE.Clientes.API.Data
{
    public class ClientesContext : DbContext, IUnitOfWork
    {
        public ClientesContext(DbContextOptions<ClientesContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                x => x.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            // onde tem relacionamento desabilitar o delete em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(c => c.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientesContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }
}

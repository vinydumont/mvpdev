using Microsoft.EntityFrameworkCore;
using MVPDev.Dtos;

namespace MVPDev.Context {
    public class ClienteDbContext : DbContext {
        public DbSet<ClienteResponse> Clientes { get; set; }

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        { 

            
        }
    }
}

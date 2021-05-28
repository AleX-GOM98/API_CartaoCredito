using Microsoft.EntityFrameworkCore;

namespace API_CartaoCredito.Domain.Models
{
    public  class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
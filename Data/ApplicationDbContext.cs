using Microsoft.EntityFrameworkCore;
using ConnectFlow.Models;

namespace ConnectFlow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }
        public DbSet<LogTransacao> Logs { get; set; }
    }
}
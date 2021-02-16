using ProjetoAspNet.Domain;
using System.Data.Entity;

namespace ProjetoAspNet.Data
{
    public class SistemaDbContext : DbContext
    {
        public SistemaDbContext() : base("SistemaNotas")
        {

        }

        public DbSet<Notas> Notas { get; set; }

        public DbSet<Caderno> Cadernoes { get; set; }
    }
}
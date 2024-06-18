using Microsoft.EntityFrameworkCore;

namespace ProjetoProcura.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {


        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Animal> Animal { get; set; }

        public DbSet<Observacoes> Observacoes { get; set; }

       

    }
}

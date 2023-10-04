using Microsoft.EntityFrameworkCore;
using ProjetoEmpreendeMaster.Models;

namespace ProjetoEmpreendeMaster.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("USUARIO").HasKey(x => x.Id);

            modelBuilder.Entity<TipoUsuario>()
                .ToTable("TIPO_USUARIO").HasKey(x => x.Id);

            modelBuilder.Entity<Atividade>()
                .ToTable("ATIVIDADE").HasKey(x => x.Id);
        }

    }
}

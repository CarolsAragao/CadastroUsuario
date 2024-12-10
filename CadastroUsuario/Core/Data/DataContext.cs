using CadastroUsuario.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>()
                .Property(u => u.Escolaridade)
                .HasConversion<int>();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}
    }
}


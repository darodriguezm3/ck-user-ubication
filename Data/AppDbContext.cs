using Microsoft.EntityFrameworkCore;
using UserRegistrationApi.Models;

namespace UserRegistrationApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet para User
        public DbSet<User> Users { get; set; }

        // DbSet para Town
        public DbSet<Town> Towns { get; set; }

        // Department
        public DbSet<Department> Departments { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>()
                .Property(t => t.TownId)
                .HasColumnName("town_id");

                
            base.OnModelCreating(modelBuilder);
            // Configurar tablas existentes en la base de datos
            modelBuilder.Entity<Town>().ToTable("town"); // Asignar la tabla manualmente
            modelBuilder.Entity<User>().ToTable("User"); // Asegúrate de hacer lo mismo para otras entidades
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Country>().ToTable("Country");

        }
    }
}

using Microsoft.EntityFrameworkCore;
using CapaDatos.Modelos;

namespace CapaDatos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Diagnosticos> Diagnosticos { get; set; }
        public DbSet<HistorialConsultas> HistorialConsultas { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Tratamientos> Tratamientos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultas>()
         .HasOne(c => c.Paciente)
         .WithMany(p => p.Consulta)
         .HasForeignKey(c => c.idPaciente)
         .IsRequired(false) // ❌ Ahora es opcional
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pagos>()
                .HasOne(p => p.Consulta)
                .WithMany(c => c.Pagos)
                .HasForeignKey(p => p.IdConsulta)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Diagnosticos>()
                .HasOne(d => d.Consulta)
                .WithOne()
                .HasForeignKey<Diagnosticos>(d => d.IdConsulta)
                .IsRequired(false); // ❌ Ahora es opcional

            modelBuilder.Entity<Tratamientos>()
                .HasOne(t => t.Paciente)
                .WithMany(p => p.Tratamientos)
                .HasForeignKey(t => t.IdPaciente)
                .IsRequired(false) // ❌ Ahora es opcional
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tratamientos>()
                .HasOne(t => t.Consulta)
                .WithMany(c => c.Tratamientos)
                .HasForeignKey(t => t.IdConsulta)
                .IsRequired(false) // ❌ Ahora es opcional
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HistorialConsultas>()
                .HasOne(h => h.Paciente)
                .WithMany(p => p.HistorialConsultas)
                .HasForeignKey(h => h.IdPaciente)
                .IsRequired(false) // ❌ Ahora es opcional
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistorialConsultas>()
                .HasOne(h => h.Consulta)
                .WithMany()
                .HasForeignKey(h => h.IdConsultas)
                .IsRequired(false) // ❌ Ahora es opcional
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacientes>()
                .HasOne(p => p.Usuario)
                .WithOne()
                .HasForeignKey<Pacientes>(p => p.UsuarioId)
                .IsRequired(false) // ❌ Ahora es opcional
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medicos>()
                .HasOne(m => m.Usuario)
                .WithOne()
                .HasForeignKey<Medicos>(m => m.UsuarioId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // Propiedades adicionales
            modelBuilder.Entity<Pagos>()
                .Property(p => p.FechaPago)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Tratamientos>()
                .Property(t => t.NombreTratamiento)
                .IsRequired()
                .HasMaxLength(200);

            // ✅ Configuración global para strings (FIXED)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType != null) // Evita errores con entidades Shadow
                {
                    var properties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(string));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.ClrType)
                            .Property(property.Name)
                            .HasMaxLength(255);
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }




    }
}

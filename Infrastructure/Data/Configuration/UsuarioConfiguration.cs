using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("usuario");
            builder.Property(p => p.Id)
                    .IsRequired();
                    
            builder.Property(p => p.Username)
                    .IsRequired()
                    .HasMaxLength(200);
                    
            builder.HasIndex(p => new {
                p.Username,
                p.Email
            }).HasDatabaseName("IX_MiIndice")
            .IsUnique();

            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(200);

            builder
            .HasMany(p => p.Roles)
            .WithMany(p => p.Usuarios)
            .UsingEntity<UsuariosRoles>(
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.UsuariosRoles)
                    .HasForeignKey(pt => pt.IdRol),
                j => j
                    .HasOne(pt => pt.Usuario)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(pt => pt.IdUsuario),
                j =>
                {
                    j.HasKey(t => new { t.IdUsuario, t.IdRol });
                });

        }
    }
}
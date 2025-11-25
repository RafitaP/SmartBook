using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("personas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tipo).HasConversion<string>();
            builder.Property(x => x.Rol).HasConversion<string>();
            builder.Property(x => x.CreadoEn).HasColumnName("creado_en");
            builder.Property(x => x.ActualizadoEn).HasColumnName("actualizado_en");
            builder.Property(x => x.PasswordHash).HasColumnName("password_hash");
            builder.Property(x => x.EmailVerificado).HasColumnName("email_verificado");
            builder.Property(x => x.FechaNacimiento).HasColumnName("fecha_nacimiento");
        }
    }
}
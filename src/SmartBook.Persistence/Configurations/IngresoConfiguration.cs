using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class IngresoConfiguration : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {
            builder.ToTable("ingresos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");
            builder.Property(x => x.CreadoEn).HasColumnName("creado_en");
            builder.Property(x => x.ActualizadoEn).HasColumnName("actualizado_en");
        }
    }
}
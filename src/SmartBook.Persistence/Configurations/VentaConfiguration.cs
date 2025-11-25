using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("ventas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).HasColumnName("cliente_id");
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");
            builder.Property(x => x.NumeroReciboPago).HasColumnName("numero_recibo_pago");
            builder.Property(x => x.CreadoEn).HasColumnName("creado_en");
            builder.Property(x => x.ActualizadoEn).HasColumnName("actualizado_en");
        }
    }
}
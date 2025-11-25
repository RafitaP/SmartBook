using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("detalle_ventas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.VentaId).HasColumnName("venta_id");
            builder.Property(x => x.LoteId).HasColumnName("lote_id");
            builder.Property(x => x.PrecioUnit).HasColumnName("precio_unit");
        }
    }
}
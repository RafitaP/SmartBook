using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class DetalleIngresoConfiguration : IEntityTypeConfiguration<DetalleIngreso>
    {
        public void Configure(EntityTypeBuilder<DetalleIngreso> builder)
        {
            builder.ToTable("detalle_ingresos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IngresoId).HasColumnName("ingreso_id");
            builder.Property(x => x.LoteId).HasColumnName("lote_id");
            builder.Property(x => x.ValorVentaPub).HasColumnName("valor_venta_pub");
        }
    }
}
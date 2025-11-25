using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("inventario");
            builder.HasKey(x => x.LoteId);
            builder.Property(x => x.LoteId).HasColumnName("lote_id");
            builder.Property(x => x.CreadoEn).HasColumnName("creado_en");
            // if you want to ignore ActualizadoEn or others, do it here:
            builder.Ignore(x => x.ActualizadoEn);
        }
    }
}
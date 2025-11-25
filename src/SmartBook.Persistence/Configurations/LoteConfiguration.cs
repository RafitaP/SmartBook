using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class LoteConfiguration : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable("lotes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LibroId).HasColumnName("libro_id");
            builder.Property(x => x.CreadoEn).HasColumnName("creado_en");
            builder.Property(x => x.ActualizadoEn).HasColumnName("actualizado_en");
            builder.Property(x => x.Codigo).HasMaxLength(100);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("libros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tipo).HasConversion<string>();
            builder.Property(x => x.CreadoEn).HasColumnName("creado_en");
            builder.Property(x => x.ActualizadoEn).HasColumnName("actualizado_en");
        }
    }
}
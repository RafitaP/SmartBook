using Microsoft.EntityFrameworkCore;
using SmartBook.Domain.Entities;
using SmartBook.Persistence.Configurations;

namespace SmartBook.Persistence;

public class SmartBookDbContext : DbContext
{
    public DbSet<Persona> Personas => Set<Persona>();
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Lote> Lotes => Set<Lote>();
    public DbSet<Ingreso> Ingresos => Set<Ingreso>();
    public DbSet<DetalleIngreso> DetalleIngresos => Set<DetalleIngreso>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<DetalleVenta> DetalleVentas => Set<DetalleVenta>();
    public DbSet<Inventario> Inventario => Set<Inventario>();

    public SmartBookDbContext(DbContextOptions<SmartBookDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonaConfiguration());
        modelBuilder.ApplyConfiguration(new LibroConfiguration());
        modelBuilder.ApplyConfiguration(new LoteConfiguration());
        modelBuilder.ApplyConfiguration(new IngresoConfiguration());
        modelBuilder.ApplyConfiguration(new DetalleIngresoConfiguration());
        modelBuilder.ApplyConfiguration(new VentaConfiguration());
        modelBuilder.ApplyConfiguration(new DetalleVentaConfiguration());
        modelBuilder.ApplyConfiguration(new InventarioConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
using Microsoft.EntityFrameworkCore;
using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Exceptions;
using SmartBook.Application.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Services
{
    public class VentasService : IVentasService
    {
        private readonly SmartBookDbContext _db;
        public VentasService(SmartBookDbContext db) { _db = db; }

        public async Task<uint> CrearAsync(CrearVentaDto dto)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new BusinessRuleException("La venta debe tener ítems.");
            foreach (var it in dto.Items)
                if (it.Unidades <= 0) throw new BusinessRuleException("Las unidades deben ser positivas.");

            await using var tx = await _db.Database.BeginTransactionAsync();

            // Validar stock por lote
            foreach (var it in dto.Items)
            {
                var inv = await _db.Inventario.SingleOrDefaultAsync(i => i.LoteId == it.LoteId);
                if (inv == null || inv.Stock < it.Unidades)
                    throw new BusinessRuleException($"Stock insuficiente en lote {it.LoteId}.");
            }

            // Cabecera
            var venta = new Venta
            {
                NumeroReciboPago = dto.NumeroReciboPago,
                Fecha = DateTime.UtcNow,
                ClienteId = dto.ClienteId,
                UsuarioId = dto.UsuarioId,
                Observaciones = dto.Observaciones,
                CreadoEn = DateTime.UtcNow
            };
            _db.Ventas.Add(venta);
            await _db.SaveChangesAsync();

            // Detalle + descuento inventario
            foreach (var it in dto.Items)
            {
                _db.DetalleVentas.Add(new DetalleVenta
                {
                    VentaId = venta.Id,
                    LoteId = it.LoteId,
                    Unidades = it.Unidades,
                    PrecioUnit = it.PrecioUnit
                });
                var inv = await _db.Inventario.SingleAsync(i => i.LoteId == it.LoteId);
                inv.Stock -= it.Unidades;
            }
            await _db.SaveChangesAsync();

            await tx.CommitAsync();
            return venta.Id;
        }
    }
}

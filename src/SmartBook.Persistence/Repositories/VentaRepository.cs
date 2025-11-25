using Microsoft.EntityFrameworkCore;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Repositories
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        private readonly SmartBookDbContext _ctx;

        public VentaRepository(SmartBookDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Venta>> SearchAsync(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            uint? clienteId,
            uint? usuarioId,
            string? numeroRecibo)
        {
            var q = _ctx.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.Items)
                    .ThenInclude(i => i.Lote)
                        .ThenInclude(l => l.Libro)
                .AsQueryable();

            if (fechaDesde.HasValue)
                q = q.Where(v => v.Fecha >= fechaDesde.Value);

            if (fechaHasta.HasValue)
                q = q.Where(v => v.Fecha <= fechaHasta.Value);

            if (clienteId.HasValue)
                q = q.Where(v => v.ClienteId == clienteId.Value);

            if (usuarioId.HasValue)
                q = q.Where(v => v.UsuarioId == usuarioId.Value);

            if (!string.IsNullOrWhiteSpace(numeroRecibo))
            {
                var nr = numeroRecibo.Trim().ToUpper();
                q = q.Where(v => v.NumeroReciboPago.ToUpper() == nr);
            }

            return await q
                .OrderByDescending(v => v.Fecha)
                .ToListAsync();
        }
    }
}

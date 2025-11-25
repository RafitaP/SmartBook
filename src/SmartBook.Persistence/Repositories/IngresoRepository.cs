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
    public class IngresoRepository : Repository<Ingreso>, IIngresoRepository
    {
        private readonly SmartBookDbContext _ctx;

        public IngresoRepository(SmartBookDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Ingreso>> SearchAsync(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            uint? usuarioId,
            uint? loteId)
        {
            var q = _ctx.Ingresos
                .Include(i => i.Usuario)
                .Include(i => i.Items)
                    .ThenInclude(ii => ii.Lote)
                        .ThenInclude(l => l.Libro)
                .AsQueryable();

            if (fechaDesde.HasValue)
                q = q.Where(i => i.Fecha >= fechaDesde.Value);

            if (fechaHasta.HasValue)
                q = q.Where(i => i.Fecha <= fechaHasta.Value);

            if (usuarioId.HasValue)
                q = q.Where(i => i.UsuarioId == usuarioId.Value);

            if (loteId.HasValue)
                q = q.Where(i => i.Items.Any(x => x.LoteId == loteId.Value));

            return await q
                .OrderByDescending(i => i.Fecha)
                .ToListAsync();
        }
    }
}

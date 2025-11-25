using SmartBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<IEnumerable<Venta>> SearchAsync(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            uint? clienteId,
            uint? usuarioId,
            string? numeroRecibo);
    }
}

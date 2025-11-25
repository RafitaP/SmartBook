using SmartBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IIngresoRepository : IRepository<Ingreso>
    {
        Task<IEnumerable<Ingreso>> SearchAsync(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            uint? usuarioId,
            uint? loteId);
    }
}

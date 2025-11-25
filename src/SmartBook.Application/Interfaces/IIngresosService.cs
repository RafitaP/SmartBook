using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IIngresosService
    {
        Task<IEnumerable<IngresoResponse>> BuscarAsync(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            uint? usuarioId,
            uint? loteId);

        Task<uint> CrearAsync(CrearIngresoDto dto);
    }
}

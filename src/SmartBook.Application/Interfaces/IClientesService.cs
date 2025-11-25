using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IClientesService
    {
        Task<uint> CrearAsync(CrearClienteDto dto);
        Task<ClienteResponse?> ObtenerPorIdentificacionAsync(string identificacion);
        Task<IEnumerable<ClienteResponse>> BuscarAsync(string? nombres);
        Task ActualizarAsync(string identificacion, CrearClienteDto dto);
    }
}

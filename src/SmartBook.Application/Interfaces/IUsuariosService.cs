using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IUsuariosService
    {
        Task<uint> CrearAsync(CrearUsuarioDto dto);
        Task<IEnumerable<UsuarioResponse>> BuscarAsync(string? nombres, string? rol);
    }
}

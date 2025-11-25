using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface ILibrosService
    {
        Task<uint> CrearAsync(CrearLibroDto dto);
        Task<LibroResponse?> ObtenerAsync(uint id);
        Task<IEnumerable<LibroResponse>> BuscarAsync(string? nombre, string? nivel, string? tipo, string? editorial, string? edicion);
        Task ActualizarAsync(uint id, CrearLibroDto dto); // Stock protegido
    }
}

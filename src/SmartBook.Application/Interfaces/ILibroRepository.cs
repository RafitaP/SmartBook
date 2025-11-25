using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface ILibroRepository : IRepository<Libro>
    {
        Task<bool> ExistsAsync(string nombre, string nivel, TipoLibro tipo, string editorial, string edicion);
        Task<IEnumerable<Libro>> SearchAsync(string? nombre, string? nivel, string? tipo, string? editorial, string? edicion);
    }
}

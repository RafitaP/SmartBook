using SmartBook.Domain.Entities;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IUsuarioRepository : IRepository<Persona>
    {
        Task<Persona?> GetByIdentificacionAsync(string identificacion);
    }
}

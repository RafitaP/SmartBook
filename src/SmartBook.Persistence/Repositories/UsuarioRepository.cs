using Microsoft.EntityFrameworkCore;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using SmartBook.Persistence;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Repositories
{
    public class UsuarioRepository : Repository<Persona>, IUsuarioRepository
    {
        private readonly SmartBookDbContext _ctx;

        public UsuarioRepository(SmartBookDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Persona?> GetByIdentificacionAsync(string identificacion)
        {
            return await _ctx.Personas
                .FirstOrDefaultAsync(x => x.Tipo == TipoPersona.Usuario &&
                                          x.Identificacion == identificacion);
        }
    }
}

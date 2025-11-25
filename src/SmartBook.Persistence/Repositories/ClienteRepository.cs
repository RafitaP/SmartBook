using Microsoft.EntityFrameworkCore;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using SmartBook.Persistence;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Repositories
{
    public class ClienteRepository : Repository<Persona>, IClienteRepository
    {
        private readonly SmartBookDbContext _ctx;

        public ClienteRepository(SmartBookDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Persona?> GetByIdentificacionAsync(string identificacion)
        {
            return await _ctx.Personas
                .FirstOrDefaultAsync(x => x.Tipo == TipoPersona.Cliente &&
                                          x.Identificacion == identificacion);
        }
    }
}

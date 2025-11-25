using Microsoft.EntityFrameworkCore;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using SmartBook.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Repositories
{
    public class LibroRepository : Repository<Libro>, ILibroRepository
    {
        private readonly SmartBookDbContext _ctx;

        public LibroRepository(SmartBookDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> ExistsAsync(string nombre, string nivel, TipoLibro tipo, string editorial, string edicion)
        {
            return await _ctx.Libros.AnyAsync(x =>
                x.Nombre == nombre &&
                x.Nivel == nivel &&
                x.Tipo == tipo &&
                x.Editorial == editorial &&
                x.Edicion == edicion);
        }

        public async Task<IEnumerable<Libro>> SearchAsync(string? nombre, string? nivel, string? tipo, string? editorial, string? edicion)
        {
            var q = _ctx.Libros.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                var n = nombre.Trim().ToUpper();
                q = q.Where(x => x.Nombre.ToUpper().Contains(n));
            }

            if (!string.IsNullOrWhiteSpace(nivel))
            {
                var nv = nivel.Trim().ToUpper();
                q = q.Where(x => x.Nivel.ToUpper() == nv);
            }

            if (!string.IsNullOrWhiteSpace(tipo))
            {
                var t = tipo.Trim().ToUpper();
                q = q.Where(x => x.Tipo.ToString().ToUpper() == t);
            }

            if (!string.IsNullOrWhiteSpace(editorial))
            {
                var ed = editorial.Trim().ToUpper();
                q = q.Where(x => x.Editorial.ToUpper() == ed);
            }

            if (!string.IsNullOrWhiteSpace(edicion))
            {
                var edc = edicion.Trim().ToUpper();
                q = q.Where(x => x.Edicion.ToUpper() == edc);
            }

            return await q
                .OrderBy(x => x.Nombre)   
                .ToListAsync();
        }
    }
}

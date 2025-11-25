using SmartBook.Application.Dtos.Responses;
using SmartBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly SmartBookDbContext _db;
        public InventarioService(SmartBookDbContext db) { _db = db; }

        public async Task<InventarioResponse?> ObtenerPorLoteAsync(uint loteId)
        {
            var inv = await _db.Inventario.FindAsync(loteId);
            if (inv is null) return null;
            return new InventarioResponse(inv.LoteId, inv.Stock, inv.CreadoEn, inv.ActualizadoEn);
        }
    }
}
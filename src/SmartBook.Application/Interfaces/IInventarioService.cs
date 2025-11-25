using SmartBook.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IInventarioService
    {
        Task<InventarioResponse?> ObtenerPorLoteAsync(uint loteId);
    }
}

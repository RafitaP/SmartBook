using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Requests
{
    public record VentaItemDto(uint LoteId, int Unidades, decimal PrecioUnit);
}

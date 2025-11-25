using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Requests
{
    public record IngresoItemDto(uint LoteId, int Unidades, decimal ValorCompra, decimal ValorVentaPublico);
}

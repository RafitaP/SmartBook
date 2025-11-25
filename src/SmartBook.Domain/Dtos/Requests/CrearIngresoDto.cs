using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Requests
{
    public record CrearIngresoDto(uint UsuarioId, string? Observaciones, IList<IngresoItemDto> Items);
}

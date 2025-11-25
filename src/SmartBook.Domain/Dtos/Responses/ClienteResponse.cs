using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Responses
{
    public record ClienteResponse(uint Id, string Identificacion, string Nombres, string Email, string? Celular, DateTime? FechaNacimiento, DateTime CreadoEn, DateTime? ActualizadoEn);
}

using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Responses
{
    public record LibroResponse(uint Id, string Nombre, string Nivel, TipoLibro Tipo, string Editorial, string Edicion);

}

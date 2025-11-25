using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Requests
{
    public record CrearLibroDto(string Nombre, string Nivel, TipoLibro Tipo, string Editorial, string Edicion);
}

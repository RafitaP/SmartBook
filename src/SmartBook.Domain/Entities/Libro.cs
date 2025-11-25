using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Libro : BaseAuditable
    {
        public uint Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Nivel { get; set; } = default!;
        public TipoLibro Tipo { get; set; }
        public string Editorial { get; set; } = default!;
        public string Edicion { get; set; } = default!;
    }
}

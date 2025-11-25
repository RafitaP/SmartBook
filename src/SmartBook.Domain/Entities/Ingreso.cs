using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Ingreso : BaseAuditable
    {
        public uint Id { get; set; }
        public DateTime Fecha { get; set; }
        public uint UsuarioId { get; set; }
        public string? Observaciones { get; set; }
    }
}

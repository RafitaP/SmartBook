using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Venta : BaseAuditable
    {
        public uint Id { get; set; }
        public string NumeroReciboPago { get; set; } = default!;
        public DateTime Fecha { get; set; }
        public uint ClienteId { get; set; }
        public uint UsuarioId { get; set; }
        public string? Observaciones { get; set; }
    }
}

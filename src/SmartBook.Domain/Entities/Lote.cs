using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Lote : BaseAuditable
    {
        public uint Id { get; set; }
        public uint LibroId { get; set; }
        public int Anio { get; set; }
        public int Consecutivo { get; set; }
        public string Codigo { get; set; } = default!;
    }
}

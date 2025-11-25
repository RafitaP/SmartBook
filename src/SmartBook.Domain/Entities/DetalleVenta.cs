using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class DetalleVenta
    {
        public uint Id { get; set; }
        public uint VentaId { get; set; }
        public uint LoteId { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioUnit { get; set; }
    }
}

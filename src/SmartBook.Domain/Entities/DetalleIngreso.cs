using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class DetalleIngreso
    {
        public uint Id { get; set; }
        public uint IngresoId { get; set; }
        public uint LoteId { get; set; }
        public int Unidades { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVentaPub { get; set; }
    }
}

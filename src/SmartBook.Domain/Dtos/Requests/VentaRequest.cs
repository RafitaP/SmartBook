using System.Collections.Generic;

namespace SmartBook.Application.Dtos.Requests
{
    public class VentaRequest
    {
        public uint ClienteId { get; set; }
        public uint UsuarioId { get; set; }
        public string NumeroReciboPago { get; set; }
        public string Observaciones { get; set; }
        public List<DetalleVentaItem> Items { get; set; }
    }

    public class DetalleVentaItem
    {
        public uint LoteId { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioUnit { get; set; }
    }
}

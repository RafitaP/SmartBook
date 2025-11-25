using System;
using System.Collections.Generic;

namespace SmartBook.Application.Dtos.Responses
{
    public class VentaItemResponse
    {
        public uint LoteId { get; set; }
        public string LibroNombre { get; set; } = default!;
        public int Unidades { get; set; }
        public decimal PrecioUnit { get; set; }
        public decimal Subtotal => Unidades * PrecioUnit;
    }

    public class VentaResponse
    {
        public uint Id { get; set; }
        public string NumeroReciboPago { get; set; } = default!;
        public DateTime Fecha { get; set; }

        public uint ClienteId { get; set; }
        public string ClienteNombre { get; set; } = default!;

        public uint UsuarioId { get; set; }
        public string UsuarioNombre { get; set; } = default!;

        public string? Observaciones { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<VentaItemResponse> Items { get; set; } = new List<VentaItemResponse>();
    }
}

using System;
using System.Collections.Generic;

namespace SmartBook.Application.Dtos.Responses
{
    public class IngresoItemResponse
    {
        public uint LoteId { get; set; }
        public string LibroNombre { get; set; } = default!;
        public int Unidades { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVentaPublico { get; set; }
    }

    public class IngresoResponse
    {
        public uint Id { get; set; }
        public DateTime Fecha { get; set; }
        public uint UsuarioId { get; set; }
        public string UsuarioNombre { get; set; } = default!;
        public string? Observaciones { get; set; }
        public IEnumerable<IngresoItemResponse> Items { get; set; } = new List<IngresoItemResponse>();
    }
}

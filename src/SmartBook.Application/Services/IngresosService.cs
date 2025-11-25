using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using SmartBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Application.Services
{
    public class IngresosService : IIngresosService
    {
        private readonly IIngresoRepository _repo;

        public IngresosService(IIngresoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<IngresoResponse>> BuscarAsync(
            DateTime? fechaDesde,
            DateTime? fechaHasta,
            uint? usuarioId,
            uint? loteId)
        {
            var lista = await _repo.SearchAsync(fechaDesde, fechaHasta, usuarioId, loteId);

            return lista.Select(i =>
            {
                var items = i.Items.Select(x => new IngresoItemResponse
                {
                    LoteId = x.LoteId,
                    LibroNombre = x.Lote.Libro.Nombre,
                    Unidades = x.Unidades,
                    ValorCompra = x.ValorCompra,
                    ValorVentaPublico = x.ValorVentaPublico
                });

                return new IngresoResponse
                {
                    Id = i.Id,
                    Fecha = i.Fecha,
                    UsuarioId = i.UsuarioId,
                    UsuarioNombre = i.Usuario.Nombres,
                    Observaciones = i.Observaciones,
                    Items = items
                };
            });
        }

        public Task<uint> CrearAsync(CrearIngresoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

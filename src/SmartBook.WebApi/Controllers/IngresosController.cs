using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Interfaces;
using System;
using System.Threading.Tasks;


namespace SmartBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresosController : ControllerBase
    {
        private readonly IIngresosService _service;

        public IngresosController(IIngresosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta,
            [FromQuery] uint? usuarioId,
            [FromQuery] uint? loteId)
        {
            var result = await _service.BuscarAsync(fechaDesde, fechaHasta, usuarioId, loteId);
            return Ok(result);
        }
    }


}

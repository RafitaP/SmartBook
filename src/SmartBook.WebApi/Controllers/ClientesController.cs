using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Dtos;
using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Interfaces;

namespace SmartBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase {
    private readonly IClientesService _svc;
    public ClientesController(IClientesService svc) { _svc = svc; }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearClienteDto dto) {
        var id = await _svc.CrearAsync(dto);
        return CreatedAtAction(nameof(ObtenerPorIdentificacion), new { identificacion = dto.Identificacion }, new { id });
    }

    [HttpGet("{identificacion}")]
    public async Task<IActionResult> ObtenerPorIdentificacion([FromRoute] string identificacion) {
        var c = await _svc.ObtenerPorIdentificacionAsync(identificacion);
        if (c is null) return NotFound();
        return Ok(c);
    }

    [HttpGet]
    public async Task<IActionResult> Buscar([FromQuery] string? nombres) {
        var list = await _svc.BuscarAsync(nombres);
        return Ok(list);
    }

    [HttpPut("{identificacion}")]
    public async Task<IActionResult> Actualizar([FromRoute] string identificacion, [FromBody] CrearClienteDto dto) {
        await _svc.ActualizarAsync(identificacion, dto);
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Dtos;
using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Interfaces;

namespace SmartBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase {
    private readonly ILibrosService _svc;
    public LibrosController(ILibrosService svc) { _svc = svc; }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearLibroDto dto) {
        var id = await _svc.CrearAsync(dto);
        return CreatedAtAction(nameof(Obtener), new { id }, new { id });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Obtener([FromRoute] int id) {
        var l = await _svc.ObtenerAsync((uint)id);
        if (l is null) return NotFound();
        return Ok(l);
    }

    [HttpGet]
    public async Task<IActionResult> Buscar([FromQuery] string? nombre, [FromQuery] string? nivel, [FromQuery] string? tipo, [FromQuery] string? editorial, [FromQuery] string? edicion) {
        var list = await _svc.BuscarAsync(nombre, nivel, tipo, editorial, edicion);
        return Ok(list);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar([FromRoute] int id, [FromBody] CrearLibroDto dto) {
        await _svc.ActualizarAsync((uint)id, dto);
        return Ok();
    }
}
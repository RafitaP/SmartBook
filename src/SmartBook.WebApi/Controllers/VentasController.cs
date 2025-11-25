using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Dtos;
using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Interfaces;
using SmartBook.Persistence.Services;

namespace SmartBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VentasController : ControllerBase {
    private readonly IVentasService _svc;
    public VentasController(IVentasService svc) { _svc = svc; }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearVentaDto dto) {
        var id = await _svc.CrearAsync(dto);
        return CreatedAtAction(nameof(Obtener), new { id }, new { id });
    }

    [HttpGet("{id:int}")]
    public IActionResult Obtener([FromRoute] int id) => Ok(new { id, detalle = "TODO: implementar consulta completa" });

    [HttpGet]
    public IActionResult Buscar([FromQuery] DateTime? desde, [FromQuery] DateTime? hasta, [FromQuery] string? cliente, [FromQuery] string? libro)
        => Ok(new { desde, hasta, cliente, libro, data = Array.Empty<object>() });
}

[HttpPost("ventas")]
    public async Task<IActionResult> CrearVenta(VentaRequest request)
    {
        var venta = await _ventaService.CrearVentaAsync(request);

        // Enviar correo al cliente
        await _emailService.SendEmailAsync(
            venta.ClienteCorreo,
            "Confirmación de compra - SmartBook",
            $"Gracias por su compra. Su factura es #{venta.Id}"
        );

        return Ok(venta);
    }
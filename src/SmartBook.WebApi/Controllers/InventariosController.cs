using Microsoft.AspNetCore.Mvc;
using SmartBook.Application.Interfaces;

namespace SmartBook.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventariosController : ControllerBase {
    private readonly IInventarioService _svc;
    public InventariosController(IInventarioService svc) { _svc = svc; }

    [HttpGet("{loteId:int}")]
    public async Task<IActionResult> Obtener([FromRoute] int loteId) {
        var inv = await _svc.ObtenerPorLoteAsync((uint)loteId);
        if (inv is null) return NotFound();
        return Ok(inv);
    }
}

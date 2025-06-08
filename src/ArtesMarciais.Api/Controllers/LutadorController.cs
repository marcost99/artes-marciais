using ArtesMarciais.Core.DTO;
using ArtesMarciais.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtesMarciais.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LutadorController : ControllerBase
{
    private readonly ILogger<LutadorController> _logger;
    private readonly ILutadorService _lutadorService;

    public LutadorController(ILogger<LutadorController> logger, ILutadorService lutadorService)
    {
        _logger = logger;
        _lutadorService = lutadorService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Registrar([FromBody] LutadorRegistrarDTO request)
    {
        var resultado = await _lutadorService.Registrar(request);

        return Created(string.Empty, resultado);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LutadorDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Listar()
    {
        var resultado = await _lutadorService.Listar();

        return Ok(resultado);
    }
}

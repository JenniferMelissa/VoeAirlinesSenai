using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

[Route("api/voos")]
[ApiController]

public class VooController : ControllerBase
{

    private readonly VooService _vooService;

    public VooController(VooService vooService)
    {
        _vooService = vooService;
    }

    [HttpPost]

    public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = _vooService.AdicionarVoo(dados);
        return Ok(voo);
    }

    [HttpGet]
    public IActionResult ListarVoos()
    {
        return Ok(_vooService.ListarVoos());
    }

    [HttpGet("{id}")]
    public IActionResult ListarVooPeloId(int id)
    {
        var voo = _vooService.ListarVooPeloId(id);
        if (voo != null)
        {
            return Ok(voo);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]

    public IActionResult AtualizarVoo(int id, AtualizarVooViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O Id informado na URL é diferente do Id ");
        }
        var voo = _vooService.AtualizarVoo(dados);
        return Ok(voo);

    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirVoo(int id)
    {
        _vooService.ExluirVoo(id);
        return NoContent();
    }







}
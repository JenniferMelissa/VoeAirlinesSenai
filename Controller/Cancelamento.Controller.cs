using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

[Route("api/cancelamentos")]
[ApiController]

public class CancelamentoController : ControllerBase
{

    private readonly CancelamentoService _cancelamentoService;

    public CancelamentoController(CancelamentoService cancelamentoService)
    {

        _cancelamentoService = cancelamentoService;
    }
    [HttpPost]

    public IActionResult AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {
        var cancelamento = _cancelamentoService.AdicionarCancelamento(dados);
        return Ok(cancelamento);
    }

    [HttpGet]
    public IActionResult ListarCancelamento()
    {
        return Ok(_cancelamentoService.ListarCancelamento());
    }

    [HttpGet("{id}")]

    public IActionResult ListarCancelamentoPeloId(int id)
    {
        var cancelamento = _cancelamentoService.ListarCancelamentoPeloId(id);
        if (cancelamento != null)
        {
            return Ok(cancelamento);
        }
            return NotFound();
    }

    [HttpPut("{id}")]

    public IActionResult AtualizarCancelamento(int id, AtualizarCancelamentoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O Id informado na URL é diferente do Id ");

        }
        var cancelamento = _cancelamentoService.AtualizarCancelamento(dados);
        return Ok(cancelamento);

    }

       [HttpDelete("{id}")]

    public IActionResult ExcluirCancelamento(int id)
    {
        _cancelamentoService.ExcluirCancelamento(id);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

[Route("api/manutencoes")]
[ApiController]

public class ManutencaoController : ControllerBase{

    private readonly ManutencaoService _manutencaoService;

    public ManutencaoController(ManutencaoService manutencaoService)
    {

        _manutencaoService = manutencaoService;
    }

    [HttpPost]

    public IActionResult AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    }

    [HttpGet]
    public IActionResult ListarManutencao()
    {
        return Ok(_manutencaoService.ListarManutencoes());
    }

    [HttpGet("{id}")]

    public IActionResult ListarManutencaoPeloId(int id)
    {
        var manutencao = _manutencaoService.ListarManutencaoPeloId(id);
        if (manutencao != null)
        {
            return Ok(manutencao);
        }else
        {
           return NotFound(); 
        }
    }

    [HttpPut("{id}")]

    public IActionResult AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O Id informado na URL é diferente do Id ");

        }
        var manutencao = _manutencaoService.AtualizarManutencao(dados);
        return Ok(manutencao);

    }

    [HttpDelete("{id}")]

    public IActionResult ExcluirManutencao(int id)
    {
        _manutencaoService.ExcluirManutencao(id);
        return NoContent();
    }



}
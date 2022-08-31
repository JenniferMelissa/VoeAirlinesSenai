using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;

[Route("api/pilotos")]
[ApiController]

public class PilotoController : ControllerBase{
    public readonly PilotoService _pilotoService;

    public PilotoController(PilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }

    [HttpPost]
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);
    }

    [HttpGet]
    public IActionResult ListarPiloto()
    {
        return Ok(_pilotoService.ListarPiloto());
    }

    [HttpGet("{id}")]

    public IActionResult ListarPilotoPeloId(int id){
        var piloto = _pilotoService.ListarPilotoPeloId(id);
        if(piloto != null)
        {
            return Ok(piloto);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarPiloto(int id, AtualizarPilotoViewModel dados){
        if(id != dados.Id ){
            return BadRequest("O Id informado na URL é diferente do Id");
        }
        else 
        {
            var piloto = _pilotoService.AtualizarPiloto(dados);
        return Ok(piloto);

        }
    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirPiloto(int id){
        _pilotoService.ExcluirPiloto(id);
        return NoContent();
    }




}

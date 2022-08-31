using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.ViewModels;
using VoeAirlinesSenai.Entities;

namespace VoeAirlinesSenai.Services;

public class PilotoService {

    private readonly VoeAirlinesSenaiContext _context;

    public PilotoService(VoeAirlinesSenaiContext context)
    {
        _context = context;
    }

    public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados){
        var piloto = new Piloto (dados.Nome,dados.Matricula);
        _context.Add(piloto);
        _context.SaveChanges();

        return new DetalhesPilotoViewModel (piloto.Id,piloto.Nome,piloto.Matricula);
    }

    public IEnumerable<ListarPilotoViewModel> ListarPiloto(){

        return _context.Pilotos.Select(p=>new ListarPilotoViewModel(p.Id,p.Nome,p.Matricula));
    }

    public DetalhesPilotoViewModel? ListarPilotoPeloId (int id){
        var piloto = _context.Pilotos.Find(id);
        if(piloto != null){
            return new DetalhesPilotoViewModel(piloto.Id,piloto.Nome,piloto.Matricula);
        }
        else
        {
            return null;
        }
        
    }

   
    public DetalhesPilotoViewModel? AtualizarPiloto(AtualizarPilotoViewModel dados){
        var piloto = _context.Pilotos.Find(dados.Id);

        if(piloto != null){
            piloto.Id = dados.Id;
            piloto.Nome = dados.Nome;
            piloto.Matricula = dados.Matricula;
            _context.Update(piloto);
            _context.SaveChanges();

            return new DetalhesPilotoViewModel(piloto.Id,piloto.Nome,piloto.Matricula);
        }
        else 
        {
            return null;
        }
    }
     public void ExcluirPiloto(int id){
        var piloto = _context.Pilotos.Find(id);
        if(piloto != null)
        {
            _context.Remove(piloto);
            _context.SaveChanges();
        }
    }

    }

using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.ViewModels;
using VoeAirlinesSenai.Entities;

namespace VoeAirlinesSenai.Services;

public class AeronaveServices{
    private readonly VoeAirlinesSenaiContext _context;

    public AeronaveServices(VoeAirlinesSenaiContext context){
        _context = context;
    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados){
       var aeronave = new Aeronave (dados.Fabricante,dados.Modelo,dados.Codigo);

        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel (aeronave.Id,aeronave.Fabricante, aeronave.Modelo,aeronave.Codigo);
    }

    public IEnumerable<ListarAeronaveViewModel> ListarAeronaveViewModels(){
        return _context.Aeronaves.Select(a=>new ListarAeronaveViewModel(a.Id,a.Modelo,a.Codigo));
    }

    public DetalhesAeronaveViewModel? ListarAeronavePeloId(int Id){
        var aeronave = _context.Aeronaves.Find(Id);

    }
}
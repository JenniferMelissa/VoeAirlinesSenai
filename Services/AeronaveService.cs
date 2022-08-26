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

    public IEnumerable<ListarAeronaveViewModel> ListarAeronaves(){
        return _context.Aeronaves.Select(a=>new ListarAeronaveViewModel(a.Id,a.Modelo,a.Codigo));
    }
    
    public DetalhesAeronaveViewModel? ListarAeronavePeloId(int Id){
        var aeronave = _context.Aeronaves.Find(Id);
        if(aeronave != null){
            return new DetalhesAeronaveViewModel(aeronave.Id,aeronave.Fabricante,aeronave.Modelo,aeronave.Codigo);
        }else{
            return null;
        }
    }    
        public void ExcluirAeronave(int Id){
            var aeronave = _context.Aeronaves.Find(Id);
            if(aeronave != null){
                _context.Remove(aeronave);
                _context.SaveChanges();
            }
        }
    public DetalhesAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados){
        var aeronave = _context.Aeronaves.Find(dados.Id);
        if(aeronave != null){
            aeronave.Fabricante = dados.Fabricante;
            aeronave.Modelo= dados.Modelo;
            aeronave.Codigo= dados.Codigo;
            _context.Update(aeronave);
            _context.SaveChanges();
            return  new DetalhesAeronaveViewModel(aeronave.Id,aeronave.Fabricante,aeronave.Modelo,aeronave.Codigo);
        }
        else{
            return null;
        }
    }

}
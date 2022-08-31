using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.ViewModels;
using VoeAirlinesSenai.Entities;

namespace VoeAirlinesSenai.Services;

public class VooService {
    private readonly VoeAirlinesSenaiContext _context;

    public VooService(VoeAirlinesSenaiContext context)
    {
        _context = context;
    }

    public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados){
        var voo = new Voo (dados.Origem,dados.Destino,dados.DataHoraPartida,dados.DataHoraChegada,dados.AeronaveId,dados.PilotoId);

        _context.Add(voo);
        _context.SaveChanges();

        return new DetalhesVooViewModel(voo.Id,voo.Origem,voo.Destino,voo.DataHoraPartida,voo.DataHoraChegada,dados.AeronaveId,voo.PilotoId);
    }

    public IEnumerable<ListarVooViewModel> ListarVoos(){
        return _context.Voos.Select(v=> new ListarVooViewModel(v.Id,v.Origem,v.Destino,v.DataHoraPartida,v.DataHoraChegada,v.AeronaveId,v.PilotoId));
    }

    public DetalhesVooViewModel? ListarVooPeloId(int id){
        var voo = _context.Voos.Find(id);
        if(voo != null)
        {
            return new DetalhesVooViewModel(voo.Id,voo.Origem,voo.Destino,voo.DataHoraPartida,voo.DataHoraChegada,voo.AeronaveId,voo.PilotoId);
        }
        else
        {
            return null;
        }
    }

    public void ExluirVoo(int id)
    {
        var voo = _context.Voos.Find(id);
        if(voo != null)
        {
            _context.Remove(voo);
            _context.SaveChanges();
        }
    }

    public DetalhesVooViewModel? AtualizarVoo(AtualizarVooViewModel dados){
        var voo = _context.Voos.Find(dados.Id);
        if(voo != null)
        {
            voo.Origem = dados.Origem;
            voo.Destino = dados.Destino;
            voo.DataHoraPartida = dados.DataHoraPartida;
            voo.DataHoraChegada = dados.DataHoraChegada;
            voo.AeronaveId = dados.AeronaveId;
            voo.PilotoId = dados.PilotoId;
            _context.Update(voo);
            _context.SaveChanges();
            
            return new DetalhesVooViewModel(voo.Id,voo.Origem,voo.Destino,voo.DataHoraPartida,voo.DataHoraChegada,voo.AeronaveId,voo.PilotoId);
        } 
        else
        {
            return null;
        }
    }







}
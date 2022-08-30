using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.ViewModels;
using VoeAirlinesSenai.Entities;

namespace VoeAirlinesSenai.Services;

public class ManutencaoService{
private readonly VoeAirlinesSenaiContext _context;

    public ManutencaoService(VoeAirlinesSenaiContext context){
        _context = context;
    }

    public DetalhesManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados){
       var manutencao = new Manutencao (dados.DataHora,dados.TipoManutencao,dados.AeronaveId,dados.Observacoes);

        _context.Add(manutencao);
        _context.SaveChanges();

        return new DetalhesManutencaoViewModel (manutencao.Id,manutencao.DataHora,manutencao.Observacoes,manutencao.TipoManutencao,manutencao.AeronaveId);
    }

    public IEnumerable<ListarManutencaoViewModel> ListarManutencoes(){
        return _context.Manutencoes.Select(m=>new ListarManutencaoViewModel(m.Id,m.DataHora,m.Observacoes,m.TipoManutencao,m.AeronaveId));
    }

    public DetalhesManutencaoViewModel? ListarManutencaoPeloId(int Id){
        var manutencao = _context.Manutencoes.Find(Id);
        if(manutencao != null){
            return new DetalhesManutencaoViewModel(manutencao.Id,manutencao.DataHora,manutencao.Observacoes,manutencao.TipoManutencao,manutencao.AeronaveId);
        }else{
            return null;
        }
    }    

    public void ExcluirManutencao(int Id){
            var manutencao = _context.Manutencoes.Find(Id);
            if(manutencao != null){
                _context.Remove(manutencao);
                _context.SaveChanges();
            }
        }

    public DetalhesManutencaoViewModel? AtualizarManutencao(AtualizarManutencaoViewModel dados){
        var manutencao = _context.Manutencoes.Find(dados.Id);
        if(manutencao != null){
            manutencao.DataHora = dados.DataHora;
            manutencao.Observacoes = dados.Observacoes;
            manutencao.TipoManutencao = dados.TipoManutencao;
            manutencao.AeronaveId = dados.AeronaveId;
            
            _context.Update(manutencao);
            _context.SaveChanges();
            return  new DetalhesManutencaoViewModel(manutencao.Id,manutencao.DataHora,manutencao.Observacoes,manutencao.TipoManutencao,manutencao.AeronaveId);
        }
        else{
            return null;
        }
    }

}
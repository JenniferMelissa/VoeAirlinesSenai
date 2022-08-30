using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class CancelamentoService {


    private readonly VoeAirlinesSenaiContext _context;
    

    public CancelamentoService(VoeAirlinesSenaiContext context){
        _context = context;
    }

    public DetalhesCancelamentoViewModel AdicionarCancelamento(AdicionarCancelamentoViewModel dados){
        var cancelamento = new Cancelamento (dados.Motivo,dados.DataHoraNotificacao,dados.VooId);

        _context.Add(cancelamento);
        _context.SaveChanges();

        return new DetalhesCancelamentoViewModel (cancelamento.Id,cancelamento.Motivo,cancelamento.DataHoraNotificacao,cancelamento.VooId);
    }

    public IEnumerable<ListarCancelamentoViewModel> ListarCancelamento(){
        return _context.Cancelamentos.Select(c=>new ListarCancelamentoViewModel(c.Id,c.Motivo,c.DataHoraNotificacao,c.VooId));
    }

    public DetalhesCancelamentoViewModel? ListarCancelamentoPeloId (int Id){
        var cancelamento = _context.Cancelamentos.Find(Id);
        if(cancelamento != null){
            return new DetalhesCancelamentoViewModel(cancelamento.Id,cancelamento.Motivo,cancelamento.DataHoraNotificacao,cancelamento.VooId);
        }
        return null;
    }

    public void ExcluirCancelamento(int Id){
            var cancelamento = _context.Cancelamentos.Find(Id);
            if(cancelamento != null){
                _context.Remove(cancelamento);
                _context.SaveChanges();
            }
        }

    public DetalhesCancelamentoViewModel? AtualizarCancelamento(AtualizarCancelamentoViewModel dados){
        var cancelamento = _context.Cancelamentos.Find(dados.Id);
        if(cancelamento != null){
            cancelamento.Motivo = dados.Motivo;
            cancelamento.DataHoraNotificacao= dados.DataHoraNotificacao;
            cancelamento.VooId= dados.VooId;
            _context.Update(cancelamento);
            _context.SaveChanges();
            return  new DetalhesCancelamentoViewModel (cancelamento.Id,cancelamento.Motivo,cancelamento.DataHoraNotificacao,cancelamento.VooId);
        }
        else{
            return null;
        }
    }
}
using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModels;

public class AdicionarManutencaoViewModel{
    public AdicionarManutencaoViewModel(DateTime dataHora, string? observacoes, TipoManutencao tipoManutencao, int aeronaveId)
    {
        DataHora = dataHora;
        Observacoes = observacoes;
        TipoManutencao = tipoManutencao;
        AeronaveId = aeronaveId;
    }

    public DateTime DataHora { get; set; }

    public string? Observacoes { get; set; }

    public TipoManutencao TipoManutencao { get; set; }

    public int AeronaveId { get; set; }
}
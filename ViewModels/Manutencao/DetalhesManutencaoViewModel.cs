using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModels;

public class DetalhesManutencaoViewModel{
    public DetalhesManutencaoViewModel(int id, DateTime dataHora, string? observacoes, TipoManutencao tipoManutencao, int aeronaveId)
    {
        Id = id;
        DataHora = dataHora;
        Observacoes = observacoes;
        TipoManutencao = tipoManutencao;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }

    public DateTime DataHora { get; set; }

    public string? Observacoes { get; set; }

    public TipoManutencao TipoManutencao { get; set; }

    public int AeronaveId { get; set; }

}
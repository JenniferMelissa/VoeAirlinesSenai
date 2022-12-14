namespace VoeAirlinesSenai.Entities;

using VoeAirlinesSenai.Entities.Enums;

public class Manutencao
{
    public Manutencao(DateTime dataHora, TipoManutencao tipoManutencao, int aeronaveId, string? observacoes =null)
    {
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

    public Aeronave Aeronave { get; set; } =null!;
}
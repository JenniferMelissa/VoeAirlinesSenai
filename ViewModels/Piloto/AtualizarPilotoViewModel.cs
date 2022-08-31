namespace VoeAirlinesSenai.ViewModels;

public class AtualizarPilotoViewModel{

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }

    public AtualizarPilotoViewModel(int id, string nome, string matricula)
    {
        Id = id;
        Nome = nome;
        Matricula = matricula;
    }
}
//namespace é um conjunto de classes
//namespace é uma divisão lógica

namespace VoeAirlinesSenai.Entities;

//classe é um conjunto de objetos
//objeto é uma instância de uma classe

public class Aeronave
{
    public Aeronave(string fabricante, string modelo, string codigo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }
    //Propriedades Automáticas
    //Caracteristicas do Objeto
    //Automático? Gera o Get Set
    //Métodos set - Atribui
    //Métodos get - Recupera
    //POCO - foco é o objeto

    public  int Id { get; set; }
    public string Fabricante { get; set; }
    public  string Modelo { get; set; }   
    public  string Codigo { get; set; }
   
   public ICollection<Manutencao> Manutencoes { get; set; } = null!;
   public ICollection<Voo> Voos { get; set; } = null!;
}
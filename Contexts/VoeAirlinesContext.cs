using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.EntityConfiguration;

namespace VoeAirlinesSenai.Contexts;

// : significa herança, herdar - vinculo - (do pai e da mãe) 

//esta classe VoeAirlinesSenai(filha) herda de DbContect(pai) mas pode gerar suas proprias coisas tbm 

public class VoeAirlinesSenaiContext : DbContext    
{

    private readonly IConfiguration _configuration;
    public VoeAirlinesSenaiContext (IConfiguration configuration){
        _configuration  = configuration;
    }
    
    public DbSet<Aeronave> Aeronaves => Set <Aeronave>();
    public DbSet<Manutencao> Manutencoes => Set <Manutencao>();
    public DbSet<Piloto> Pilotos => Set <Piloto>();
    public DbSet<Voo> Voos => Set <Voo>();
    public DbSet<Cancelamento> Cancelamentos => Set <Cancelamento>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
            optionBuilder.UseSqlServer(_configuration.GetConnectionString("VoeAirlines"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AeronaveConfiguration());
        modelBuilder.ApplyConfiguration(new PilotoConfiguration());
        modelBuilder.ApplyConfiguration(new VooConfiguration());
        modelBuilder.ApplyConfiguration(new CancelamentoConfiguration());
    }
}
using VoeAirlinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlinesSenai.EntityConfiguration;

public class  PilotoConfiguration : IEntityTypeConfiguration<Piloto>
{
    public void Configure(EntityTypeBuilder<Piloto> builder) 
        {
            builder.ToTable("Piloto");
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Nome)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p=>p.Matricula)
            .IsRequired()
            .HasMaxLength(10);

            builder .HasIndex(p=>p.Matricula)
            .IsUnique();
        }
        


}
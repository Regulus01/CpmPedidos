using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class ComboMap : BaseDomainMap<Combo>
{
    public ComboMap() : base("tb_combo")
    {
    }

    public override void Configure(EntityTypeBuilder<Combo> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Preco)
            .HasColumnName("preco")
            .HasPrecision(17, 5)
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("ativo")
            .IsRequired();
    }
}
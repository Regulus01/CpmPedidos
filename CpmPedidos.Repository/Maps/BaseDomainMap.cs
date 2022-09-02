using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class BaseDomainMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseDomain
{
    private readonly string _tableNome;

    public BaseDomainMap(string tableNome = "")
    {
        _tableNome = tableNome;
    }

    public virtual void Configure(EntityTypeBuilder<TDomain> builder)
    {
        if (!string.IsNullOrEmpty(_tableNome))
        {
            builder.ToTable(_tableNome);
        }

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CriadoEm)
            .HasColumnName("criado_em")
            .IsRequired();
    }
}
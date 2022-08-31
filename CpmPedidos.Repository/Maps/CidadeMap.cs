using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class CidadeMap : BaseDomainMap<Cidade>
{
    public CidadeMap() : base("tb_cidade")
    {
    }

    public override void Configure(EntityTypeBuilder<Cidade> builder)
    {
        base.Configure(builder);
    }
}
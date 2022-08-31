using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class EnderecoMap : BaseDomainMap<Endereco>
{
    public EnderecoMap() : base("tb_endereco")
    {
    }

    public override void Configure(EntityTypeBuilder<Endereco> builder)
    {
        base.Configure(builder);
    }
}
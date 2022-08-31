using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class ClienteMap : BaseDomainMap<Cliente>
{
    public ClienteMap() : base("tb_cliente")
    {
    }

    public override void Configure(EntityTypeBuilder<Cliente> builder)
    {
        base.Configure(builder);
    }
}
using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class ProdutoMap : BaseDomainMap<Produto>
{
    public ProdutoMap() : base("tb_produto")
    {
    }

    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        base.Configure(builder);
    }
}
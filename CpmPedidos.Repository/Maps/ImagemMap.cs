using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class ImagemMap : BaseDomainMap<Imagem>
{
    public ImagemMap() : base("tb_imagem")
    {
    }

    public override void Configure(EntityTypeBuilder<Imagem> builder)
    {
        base.Configure(builder);
    }
}
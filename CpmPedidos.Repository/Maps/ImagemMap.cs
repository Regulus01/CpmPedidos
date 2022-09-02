using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.NomeDoArquivo)
            .HasColumnName("nome_arquivo")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Principal)
            .HasColumnName("principal")
            .IsRequired();
    }
}
using CpmPedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository.Maps;

public class PromocaoProdutoMap : BaseDomainMap<PromocaoProduto>
{
    public PromocaoProdutoMap() : base("tb_promocao_produto")
    {
    }

    public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Preco)
            .HasColumnName("preco")
            .HasPrecision(17, 2)
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("ativo")
            .IsRequired();

        //Relacionamento um pra muitos com imagem

        builder.Property(x => x.IdImagem)
            .HasColumnName("id_cidade")
            .IsRequired();

        builder.HasOne(x => x.Imagem)
            .WithMany()
            .HasForeignKey(x => x.IdImagem);

        //relacionamento um pra muitos com produto

        builder.Property(x => x.IdProduto)
            .HasColumnName("id_produto")
            .IsRequired();

        builder.HasOne(x => x.produto)
            .WithMany(x => x.Promocoes)
            .HasForeignKey(x => x.IdProduto);
    }
}
using CpmPedidos.Domain.Interfaces;

namespace CpmPedidos.Domain.Entities;

public class PromocaoProduto : BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public bool Ativo { get; set; }
    
    public int IdImagem { get; set; }
    public virtual Imagem Imagem { get; set; }

    public int IdProduto { get; set; }
    public virtual Produto produto { get; set; }
    
}
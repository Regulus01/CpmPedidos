namespace CpmPedidos.Domain.Entities;

public class Imagem : BaseDomain
{
    public string Nome { get; set; }
    public string NomeDoArquivo { get; set; }
    public bool Principal { get; set; }
}
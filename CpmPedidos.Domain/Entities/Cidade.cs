using CpmPedidos.Domain.Interfaces;

namespace CpmPedidos.Domain.Entities;

public class Cidade : BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public string Uf { get; set; }
    public bool Ativo { get; set; }
}
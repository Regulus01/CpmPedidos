using CpmPedidos.Domain.Interfaces;

namespace CpmPedidos.Domain.Entities;

public class Cliente : BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public bool Ativo { get; set; }

    public int IdEndereco { get; set; }
    public virtual Endereco Endereco { get; set; }
}
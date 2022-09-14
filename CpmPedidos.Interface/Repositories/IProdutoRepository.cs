using CpmPedidos.Domain.Entities;

namespace CpmPedidos.Interface.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> GetAll();
    IEnumerable<Produto> Search(string text);
}
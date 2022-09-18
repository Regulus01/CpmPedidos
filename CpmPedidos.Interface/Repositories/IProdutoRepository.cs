using CpmPedidos.Domain.Entities;

namespace CpmPedidos.Interface.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> GetAll();
    dynamic Search(string text, int pagina);
    Produto Detail(int id);
}
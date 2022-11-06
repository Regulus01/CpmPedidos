using CpmPedidos.Domain.Entities;

namespace CpmPedidos.Interface.Repositories;

public interface IProdutoRepository
{
    dynamic GetAll(string ordem);
    dynamic Search(string text, int pagina, string ordem);
    dynamic Detail(int id);
    dynamic Imagens(int id);
}
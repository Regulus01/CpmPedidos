using CpmPedidos.Domain.Dtos;

namespace CpmPedidos.Interface.Repositories
{
    public interface ICidadeRepository
    {
        dynamic Get();
        int Criar(CidadeDTO model);
        int Alterar(CidadeDTO model);
    }
}

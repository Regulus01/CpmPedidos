using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;

namespace CpmPedidos.Repository.Repositories;

public class ProdutoRepository: BaseRepository, IProdutoRepository
{
    public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)  
    {     
    }

    public IEnumerable<Produto> GetAll()
    {
        return _context.Produtos.
            Where(x => x.Ativo)
            .OrderBy(x => x.Nome)
            .ToList();
    }

    public IEnumerable<Produto> Search(string text)
    {
        return _context.Produtos
            .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || 
                                    x.Descricao.ToUpper().Contains(text.ToUpper())))
            .OrderBy(x => x.Nome)
            .ToList();
    }
}
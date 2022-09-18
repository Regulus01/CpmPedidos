using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository.Repositories;

public class ProdutoRepository: BaseRepository, IProdutoRepository
{
    public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)  
    {     
    }

    public IEnumerable<Produto> GetAll()
    {
        return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Ativo)
            .OrderBy(x => x.Nome)
            .ToList();
    }

    public dynamic Search(string text, int pagina)
    {
        var produtos = _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || 
                                    x.Descricao.ToUpper().Contains(text.ToUpper())))
            .Skip(TamanhoPagina * (pagina - 1))
            .Take(TamanhoPagina)
            .OrderBy(x => x.Nome)
            .ToList();

        var quantProdutos = _context.Produtos
            .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) ||
                                    x.Descricao.ToUpper().Contains(text.ToUpper())))
            .Count();

        var quantPaginas = (quantProdutos / TamanhoPagina);
        if(quantPaginas < 1)
        {
            quantPaginas = 1;
        }

        return new { produtos, quantPaginas };
    }

    public Produto Detail(int id)
    {
        return _context.Produtos
            .Include(x => x.Imagens)
            .Include(x => x.Categoria)
            .FirstOrDefault(x => x.Ativo && x.Id == id);
    }
}
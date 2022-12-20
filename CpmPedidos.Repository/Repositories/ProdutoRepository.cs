using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository.Repositories;

public class ProdutoRepository : BaseRepository, IProdutoRepository
{
    private void OrdenarPorNome(ref IQueryable<Produto> query, string ordem)
    {
        if (string.IsNullOrEmpty(ordem) || ordem.ToUpper() == "ASC")
            query = query.OrderBy(x => x.Nome);
        else
            query = query.OrderByDescending(x => x.Nome);
    }
    
    public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public dynamic GetAll(string ordem)
    {
        var queryProduto = _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Ativo);

        OrdenarPorNome(ref queryProduto, ordem);
        
        var queryRetorno = queryProduto 
            .Select(x => new
        {
            x.Nome,
            x.Preco,
            Categoria = x.Categoria.Nome,
            Imagens = x.Imagens.Select(i => new
            {
                i.Id,
                i.Nome,
                i.NomeDoArquivo
            })
        });

        return queryRetorno.ToList();
    }

    public dynamic Search(string text, int pagina, string ordem)
    {
        var query = _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) ||
                                    x.Descricao.ToUpper().Contains(text.ToUpper())))
            .Skip(TamanhoPagina * (pagina - 1))
            .Take(TamanhoPagina);
            
        OrdenarPorNome(ref query, ordem);
        
        var queryReturn = query.Select(x => new
            {
                x.Nome,
                x.Preco,
                Categoria = x.Categoria.Nome,
                Imagens = x.Imagens.Select(i => new
                {
                    i.Id,
                    i.Nome,
                    i.NomeDoArquivo
                })
            });

        var produtos = queryReturn.ToList();

        var quantProdutos = _context.Produtos
            .Count(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) ||
                                    x.Descricao.ToUpper().Contains(text.ToUpper())));

        var quantPaginas = (int) Math.Ceiling((decimal) quantProdutos / TamanhoPagina);
        if (quantPaginas < 1)
        {
            quantPaginas = 1;
        }

        return new { produtos, quantPaginas };
    }

    public dynamic Detail(int id)
    {
        var produto = _context.Produtos
            .Include(x => x.Imagens)
            .Include(x => x.Categoria)
            .Where(x => x.Ativo && x.Id == id)
            .Select(x => new
            {
                x.Id,
                x.Nome,
                x.Codigo,
                x.Descricao,
                x.Preco,
                Categoria = new
                {
                    x.Categoria.Id,
                    x.Categoria.Nome
                },
                Imagens = x.Imagens.Select(i => new
                {
                    i.Id,
                    i.Nome,
                    i.NomeDoArquivo
                })
            })
            .FirstOrDefault();

        return produto;
    }

    public dynamic Imagens(int id)
    {
        var produto = _context.Produtos
            .Include(x => x.Imagens)
            .Include(x => x.Categoria)
            .Where(x => x.Ativo && x.Id == id)
            .SelectMany(x => x.Imagens, (produto, imagem) => new
            {
                IdProduto = produto.Id,
                imagem.Id,
                imagem.Nome,
                imagem.NomeDoArquivo
            })
            .FirstOrDefault();

        return produto;
    }
}
using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : AppBaseController
{
    public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpGet]
    public IEnumerable<Produto> GetAll()
    {
        var rep = (IProdutoRepository) _serviceProvider.GetService(typeof(IProdutoRepository))!;
        return rep.GetAll();
    }

    [HttpGet]
    [Route("search/{text}/{pagina?}")]
    public dynamic GetSearch(string text, int pagina = 1)
    {
        var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository))!;
        return rep.Search(text, pagina);
    } 
    
    [HttpGet]
    [Route("{id}")]
    public Produto? Detail(int? id)
    {
        if ((id ?? 0) > 0)
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository))!;
            return rep.Detail(id.Value);
        }
        else
        {
            return null;
        }
    }

    
}
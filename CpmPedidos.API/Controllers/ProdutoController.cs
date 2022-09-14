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
    [Route("search/{text}")]
    public IEnumerable<Produto> GetSearch(string text)
    {
        var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository))!;
        return rep.Search(text);
    }
}
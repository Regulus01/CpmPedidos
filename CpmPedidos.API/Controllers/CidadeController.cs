using CpmPedidos.Domain.Dtos;
using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : AppBaseController
    {
        public CidadeController(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {

        }

        [HttpGet]
        public dynamic? Get()
        {
            var rep = GetService<ICidadeRepository>()?.Get();
    
            return rep;
        }
    
        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>()!.Criar(model);
        }
        
        [HttpPut]
        public int Alterar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>()!.Alterar(model);
        }
        
    }
}
using CpmPedidos.Domain.Dtos;
using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository.Repositories
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        private string GetProximoNumero()
        {
            var ret = 1.ToString("00000");

            var ultimoNumero = _context.Pedidos.Max(x => x.Numero);
            if (!string.IsNullOrEmpty(ultimoNumero))
            {
                ret = (Convert.ToInt32(ultimoNumero) + 1).ToString("00000");
            }
            return ret;
        }
        public decimal TicketMaximo()
        {
            var hoje = DateTime.Today;

            return _context.Pedidos
                .Where(x => x.CriadoEm.Date.ToString() == hoje.ToString())
                .Max(x => (decimal?) x.ValorTotal) ?? 0;
           
        }

        public dynamic PedidosCliente()
        {
            var hoje = DateTime.Today;
            var inicioMes = new DateTime(hoje.Year, hoje.Month, 1);
            var finalMes = new DateTime(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));

            return _context.Pedidos
                .Where(x => x.CriadoEm.Date >= inicioMes && x.CriadoEm.Date <= finalMes)
                .GroupBy(pedido => new {pedido.IdCliente, pedido.Cliente.Nome}, 
                    (chave, pedidos) => new
                    {
                    Cliente = chave.Nome,
                    Pedidos = pedidos.Count(),
                    Total = pedidos.Sum(pedido => pedido.ValorTotal)
                })
                .ToList();
                
                /*
                .GroupBy(pedido => new {pedido.IdCliente, pedido.Cliente.Nome})
                .Select(x => new
                {
                    Cliente = x.Key.Nome,
                    Pedidos = x.Count(),
                    Total = x.Sum(p => p.ValorTotal)
                })
                .ToList();
                */
        }

        public string SalvarPedido(PedidoDTO pedido)
        {
            var ret = "";

            var cont = 0;
            
            try
            {
                var entity = new Pedido
                {
                    Numero = GetProximoNumero(),
                    IdCliente = pedido.IdCliente,
                    CriadoEm = DateTime.Now,
                    Produtos = new List<ProdutoPedido>()
                };

                var valorTotal = 0m;

                foreach (var prodPed in pedido.Produtos)
                {
                    var precoProduto = _context.Produtos
                        .Where(x => x.Id == prodPed.IdProduto)
                        .Select(x => x.Preco)
                        .FirstOrDefault();

                    if (precoProduto > 0)
                    {
                        valorTotal += prodPed.Quantidade * precoProduto;
                        entity.Produtos.Add(new ProdutoPedido()
                        {
                            IdProduto = prodPed.IdProduto,
                            Quantidade = prodPed.Quantidade,
                            Preco = precoProduto

                        });
                    }
                }

                entity.ValorTotal = valorTotal;
                _context.Pedidos.Add(entity);
                _context.SaveChanges();

                ret = entity.Numero;
            }
            catch (Exception)
            {
                
            }

            return ret;
        }
    }
}

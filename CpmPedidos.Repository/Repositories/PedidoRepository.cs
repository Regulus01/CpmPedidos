using CpmPedidos.Interface.Repositories;

namespace CpmPedidos.Repository.Repositories
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
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
    }
}

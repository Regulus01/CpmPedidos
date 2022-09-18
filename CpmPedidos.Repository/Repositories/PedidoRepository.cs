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
    }
}

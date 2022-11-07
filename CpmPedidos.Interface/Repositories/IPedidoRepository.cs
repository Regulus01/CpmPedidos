using CpmPedidos.Domain.Dtos;

namespace CpmPedidos.Interface.Repositories
{
    public interface IPedidoRepository
    {
        decimal TicketMaximo();
        dynamic PedidosCliente();
        string SalvarPedido(PedidoDTO pedido);
    }
}

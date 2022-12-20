using CpmPedidos.Domain.Dtos;

namespace CpmPedidos.Interface.Repositories
{
    public interface IPedidoRepository
    {      //finalizado
        decimal TicketMaximo();
        dynamic PedidosCliente();
        string SalvarPedido(PedidoDTO pedido);
    }
}

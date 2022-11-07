namespace CpmPedidos.Domain.Dtos;

public class PedidoDTO
{
    public int IdCliente { get; set; }
    public List<ProdudoPedidoDTO> Produtos { get; set; }
}
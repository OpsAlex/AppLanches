using AppLanches.Models;
using System.Collections.Generic;

namespace AppLanches.Repository
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
        Pedido GetPedidoById(int pedidoId);
        List<Pedido> GetPedidos();
    }
}

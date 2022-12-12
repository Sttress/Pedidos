using Pedidos.Bussines.DTO;
using Pedidos.Bussines.Entities;
using Pedidos.Models.Pedido;

namespace Pedidos.Bussines.Repositories
{
    public interface IPedidoRepository
    {
        JsonPedidoDTO GetPedido(int Id);
        void Add(PedidoViewModelInput modelo);
        void Edit(Pedido modelo);
        void Remove(int Id);
        void Commit();

    }
}

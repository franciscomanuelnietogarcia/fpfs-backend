using Entities.Entities;

namespace WebApplication1.IServices
{
    public interface IOrderService
    {
        int InsertOrder(OrderItem orderItem);
        void DeleteOrder(int id);
        List<OrderItem> GetAllOrders();
        List<OrderItem> GetOrderById(int OrderId);

    }
}

using Data;
using Entities.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class OrderService : BaseContextService, IOrderService
    {
        public OrderService(ServiceContext serviceContext) : base(serviceContext) 
        {
        }

        public int InsertOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
            return orderItem.OrderId;
        }
        public List<OrderItem> GetAllOrders()
        {
            return _serviceContext.Set<OrderItem>()
                .ToList();

        }
        public List<OrderItem> GetOrderById(int id)
        {
            var resultList = _serviceContext.Set<OrderItem>()

                                .Where(u => u.OrderId == id);


            return resultList.ToList();
        }
        public void DeleteOrder(int id)
        {

            var orderToDelete = _serviceContext.Set<OrderItem>()
                 .Where(u => u.OrderId == id).First();

            _serviceContext.SaveChanges();

        }
    }   
}

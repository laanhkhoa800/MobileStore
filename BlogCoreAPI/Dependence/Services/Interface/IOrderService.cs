using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services.Interface
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        IEnumerable<Order> getListOrder();
        IEnumerable<Order> getListOrderByStatus(int StatusOrderId);
        IEnumerable<Order> getOrderByUserId(int id);
        void UpdateOrder(Order order);
        Order GetOrderByOrderId(int orderId);

        void SaveOrder();
    }
}

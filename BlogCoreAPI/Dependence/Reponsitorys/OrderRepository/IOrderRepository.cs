using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.OrderRepository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> getOrderByUserId(int id);
        IEnumerable<Order> getListByStatusOrder(int StatusOrderId);
    }
}

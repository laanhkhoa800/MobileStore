using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Reponsitorys.OrderRepository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private ApContext _apContext;
        public OrderRepository(ApContext context) : base(context)
        {
            _apContext = context;
        }

        public IEnumerable<Order> getListByStatusOrder(int StatusOrderId)
        {
            return _apContext.orders.Where(o => o.StatusOrderId == StatusOrderId).ToList();
        }

        public IEnumerable<Order> getOrderByUserId(int id)
        {
            return _apContext.orders.Where(o => o.UserId == id).ToList();
         }
    }
}

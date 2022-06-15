using BlogCoreAPI.Dependence.Reponsitorys.OrderRepository;
using BlogCoreAPI.Dependence.Services.Interface;
using BlogCoreAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Dependence.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CreateOrder(Order order)
        {
            order.CreateAt = DateTime.Now;
            order.StatusOrderId = 1;
            _orderRepository.Inser(order);
        }

        public IEnumerable<Order> getListOrder()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> getListOrderByStatus(int StatusOrderId)
        {
            return _orderRepository.getListByStatusOrder(StatusOrderId);
        }

        public Order GetOrderByOrderId(int orderId)
        {
            return _orderRepository.GetByID(orderId);
        }

        public IEnumerable<Order> getOrderByUserId(int id)
        {
            return _orderRepository.getOrderByUserId(id);
        }

        public void SaveOrder()
        {
            _orderRepository.Save();
        }

        public void UpdateOrder(Order order)
        {
            order.StatusOrderId+=1;
            _orderRepository.Update(order);
        }
    }
}

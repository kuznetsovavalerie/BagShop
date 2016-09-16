using BagShop.Common.Entities;
using BagShop.Common.Enums;
using BagShop.Common.Interfaces;
using BagShop.Common.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BagShop.BLL.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public IEnumerable<Order> GetAllItems()
        {
            return unitOfWork.OrderRepository.GetAll();
        }

        public IEnumerable<Order> GetBySearchCriteria(OrderStateType type)
        {
            return unitOfWork.OrderRepository.GetAll();
        }

        public Order GetItem(int id)
        {
            return unitOfWork.OrderRepository.FindById(id);
        }

        public void AddItem(Order item, Guid customerId)
        {
            var customer = unitOfWork.UserRepository.FindById(customerId);
            item.Customer = customer;

            var state = new OrderState()
            {
                Type = OrderStateType.Created,
                ChangeDate = DateTime.Now,
                StateManager = customer
            };

            item.States.Add(state);
            unitOfWork.OrderRepository.Add(item);
        }

        public void AddState(int orderId, OrderState state)
        {
            var order = unitOfWork.OrderRepository.FindById(orderId);

            state.ChangeDate = DateTime.Now;
            order.States.Add(state);
            unitOfWork.OrderRepository.Update(order);
        }
    }
}

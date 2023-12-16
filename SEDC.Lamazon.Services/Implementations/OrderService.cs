using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.Order;
using SEDC.Lamazon.Services.ViewModels.OrderItem;

namespace SEDC.Lamazon.Services.Implementations;

public class OrderService : IOrderService
{
    public readonly IOrderRepository _orderRepository;
    public  OrderService (IOrderRepository orderRepository) 
    {
        _orderRepository = orderRepository;
    }

    public void CreateOrder(OrderViewModel order)
    {
        Order newOrder = new Order()
        {
            OrderDAte = DateTime.UtcNow,
            IsActive = true,
            OrderNumber = $"{DateTime.UtcNow.ToLongDateString().ToString()}_{order.UserId}",
            UserId = order.UserId,
        };

        _orderRepository.Insert(newOrder); 
    }

    public OrderViewModel GetActiveOrder(int userId)
    {
        Order activeOrder = _orderRepository.GetActiveOrder(userId);

        OrderViewModel activeOrderViewModel = null;

        if (activeOrder != null) 
        {
            activeOrderViewModel = new OrderViewModel()
            {
                OrderDate = activeOrder.OrderDAte,
                OrderNumber = activeOrder.OrderNumber,
                Id = activeOrder.Id,
                UserId = userId,
                TotalPrice = activeOrder.TotalPrice,
                User = new ViewModels.User.UserViewModel()
                {
                    FullName = activeOrder.User.FullName
                },
                Items = activeOrder.Items.Select(o => new OrderItemViewModel()
                {
                    Id = o.Id,
                    Price = o.Price,
                    OrderId = o.OrderId,
                    Qty= o.Quantity,
                    Product = new ViewModels.Product.ProductViewModel() 
                    {
                        Name = o.Product.Name,
                        Description = o.Product.Description,
                        ImageUrl = o.Product.ImageUrl,
                        Price= o.Product.Price,
                        Id = o.ProductId
                    }
                }).ToList()
            };
            activeOrderViewModel.TotalPrice =
                activeOrderViewModel
                .Items
                .Sum(o => o.Price * o.Qty);
        }
        return activeOrderViewModel;
    }

    public List<OrderViewModel> GetAllOrders(int userId)
    {
        throw new NotImplementedException();
    }

    public OrderViewModel GetOrderById(int id)
    {
        throw new NotImplementedException();
    }
}

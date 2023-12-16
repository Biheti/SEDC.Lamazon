using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.Interfaces;

namespace SEDC.Lamazon.Services.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    public OrderItemService(IOrderItemRepository orderRepository, IProductRepository productRepository) 
    {
        _orderItemRepository = orderRepository;
        _productRepository = productRepository;
    }
    public void CreateOrderItem(int productId, int orderId)
    {
        Product product = _productRepository.Get(productId);
        OrderItem orderItem = new OrderItem()
        {
            OrderId = orderId,
            ProductId = productId,
            Price = product.Price,
            Quantity = 1
        };
        _orderItemRepository.Insert(orderItem);
    }

}
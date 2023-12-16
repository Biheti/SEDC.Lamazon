using SEDC.Lamazon.Services.ViewModels.Order;
namespace SEDC.Lamazon.Services.Interfaces;

public interface IOrderService
{
    public List<OrderViewModel> GetAllOrders(int userId);
    OrderViewModel GetOrderById(int id);
    void CreateOrder(OrderViewModel order);
    OrderViewModel GetActiveOrder(int userId);
}

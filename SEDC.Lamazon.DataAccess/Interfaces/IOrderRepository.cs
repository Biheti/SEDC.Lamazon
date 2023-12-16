using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Interfaces;

public interface IOrderRepository
{
    List<Order> GetAll();
    Order Get(int id);
    int Insert(Order order);
    void Update(Order order);
    void Delete(int id);
    Order GetActiveOrder(int UserId);
}

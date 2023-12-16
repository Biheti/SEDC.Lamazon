using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Interfaces;

public interface IOrderItemRepository
{
    List<OrderItem> GetAll();
    OrderItem Get(int id);
    int Insert(OrderItem orderItem);
    void Update(OrderItem orderItem);
    void Delete(int id);
}

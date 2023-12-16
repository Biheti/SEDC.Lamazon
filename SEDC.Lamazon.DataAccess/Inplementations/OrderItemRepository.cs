using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Context;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Inplementations;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly LamazonDbContext _dbContext;
    public OrderItemRepository(LamazonDbContext lamazonDbContext)
    {
        _dbContext = lamazonDbContext;
    }

    public void Delete(int id)
    {
        OrderItem orderItem = _dbContext
            .OrderItems
            .FirstOrDefault(o => o.Id == id);

        _dbContext.OrderItems.Remove(orderItem);
        _dbContext.SaveChanges();
    }

    public OrderItem Get(int id)
    {
        OrderItem orderItem = _dbContext
            .OrderItems
            .Include(oi => oi.Order)
            .Include(oi => oi.Product)
            .FirstOrDefault();
        return orderItem;
    }

    public List<OrderItem> GetAll()
    {
       return _dbContext
            .OrderItems
            .Include(oi => oi.Order)
            .Include(oi => oi.Product)
            .ToList();
    }

    public int Insert(OrderItem orderItem)
    {
        _dbContext.OrderItems.Add(orderItem);
        _dbContext.SaveChanges();
        return orderItem.Id;
    }

    public void Update(OrderItem orderItem)
    {
        _dbContext
            .OrderItems
            .Update(orderItem);

        _dbContext.SaveChanges();
    }
}

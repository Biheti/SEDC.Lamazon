using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Context;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Inplementations;

public class OrderRepository : IOrderRepository
{
    private readonly LamazonDbContext _dbContext;
    public OrderRepository(LamazonDbContext lamazonDbContext) 
    {
        _dbContext = lamazonDbContext;
    }
    public void Delete(int id)
    {

        Order order = _dbContext
             .Orders
             .FirstOrDefault(o => o.Id == id);

        _dbContext.Orders.Remove(order);
        _dbContext.SaveChanges();
    }

    public Order Get(int id)
    {
        Order order = _dbContext
            .Orders
            .Include(o => o.User)
            .FirstOrDefault(o => o.Id == id);

        return order;
    }

    public Order GetActiveOrder(int userId)
    {
        return _dbContext
            .Orders
            .Include(o => o.User)
            .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
            .Where(o => o.IsActive == true)
            .Where(o => o.UserId == userId)
            .FirstOrDefault();
    }

    public List<Order> GetAll()
    {
       return _dbContext.Orders.ToList();
    }

    public int Insert(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges ();
        return order.Id;
    }

    public void Update(Order order)
    {
        _dbContext
            .Orders
            .Update(order);

        _dbContext.SaveChanges ();
    }
}

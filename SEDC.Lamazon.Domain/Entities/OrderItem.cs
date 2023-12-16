namespace SEDC.Lamazon.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

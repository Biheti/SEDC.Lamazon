namespace SEDC.Lamazon.Domain.Entities;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; }
    public DateTime OrderDAte { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }  

    public bool IsActive { get; set; }
    public decimal TotalPrice { get; set; } 
}

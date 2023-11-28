namespace SEDC.Lamazon.Domain.Entities;

public class Product : BaseEntity
{
    //blob - binary large object
    public string Name { get; set; }
    public string Description { get; set; }
    public int ImageUrl { get; set; }
    public decimal Price { get; set; }

    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }

}

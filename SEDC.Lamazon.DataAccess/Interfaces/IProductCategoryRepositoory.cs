using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Interfaces;

public interface IProductCategoryRepositoory
{
    List<ProductCategory> GetAll();
    ProductCategory Get(int id);
    int Insert(ProductCategory productCategory);
    void Update(ProductCategory productCategory);
    void Delete(int id);
}

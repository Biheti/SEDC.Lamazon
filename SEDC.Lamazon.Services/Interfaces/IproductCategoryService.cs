using SEDC.Lamazon.Services.ViewModels.ProductCategory;

namespace SEDC.Lamazon.Services.Interfaces;

public interface IProductCategoryService
{

    List<ProductCategoryViewModel> GetAllProductCategories();
    ProductCategoryViewModel GetProductCategoryById (int id);
    void CreateProductCategory (ProductCategoryViewModel productCategory);
    void UpdateProductCategory (ProductCategoryViewModel productCategory);
    void DeleteProductCategory(int id);
}

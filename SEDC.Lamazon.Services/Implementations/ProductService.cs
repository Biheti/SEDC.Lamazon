using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.Product;

namespace SEDC.Lamazon.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepositoory) 
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepositoory;

    }
    public void CreateProduct(CreateProductViewModel model)
    {
        ProductCategory productCategory = _productCategoryRepository.Get(model.ProductCategoryId);
        if (productCategory == null)
            throw new Exception($"ProductCategory with id: {model.ProductCategoryId} does not exists");

        Product product = new Product()
        {
            Description = model.Description,
            Name = model.Name,
            ImageUrl = model.ImageUrl,
            Price = model.Price,
            ProductCategoryId = model.ProductCategoryId
        };
        int productId = _productRepository.Insert(product);
        if (productId == 0)
            throw new Exception("Something went wrong");
       
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(id);
    }

    public List<ProductViewModel> GetAllProducts()
    {
       List<ProductViewModel> productList = _productRepository
            .GetAll()
            .Select(p => new ProductViewModel()
            {
                Description = p.Description,
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                ProductCategoryName = p.ProductCategory.Name
            })
            .ToList();

        return productList;
    }

    public ProductViewModel GetProductById(int id)
    {
        Product dbProduct = _productRepository.Get(id);
        if (dbProduct == null)
            throw new Exception($"The product with provided id: {id} in not found");
        ProductViewModel productViewModl = new ProductViewModel()
        {
            Description = dbProduct.Description,
            Id = dbProduct.Id,
            ImageUrl = dbProduct.ImageUrl,
            Name = dbProduct.Name,
            Price = dbProduct.Price,
            ProductCategoryName = dbProduct.ProductCategory.Name
        };
        return productViewModl;
    }

    public void UpdateProduct(UpdateProductViewModel model)
    {
        throw new NotImplementedException();
    }
}

using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.ProductCategory;

namespace SEDC.Lamazon.Services.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository) 
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public void CreateProductCategory(ProductCategoryViewModel productCategory)
        {
            //TODO: Validate the date
            ProductCategory productCategoryInsert = new ProductCategory
            {
                Name = productCategory.Name
            };

            int productCategoryId = _productCategoryRepository.Insert(productCategoryInsert);

            if (productCategoryId <= 0)
                throw new Exception($"Something went wrong while saving the new category");
        }

        public void DeleteProductCategory(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public List<ProductCategoryViewModel> GetAllProductCategories()
        {
            List<ProductCategory> productCategoryList = _productCategoryRepository.GetAll();
            List<ProductCategoryViewModel> productCategoryResult = productCategoryList
                .Select(pc => new ProductCategoryViewModel()
                {
                    Id = pc.Id,
                    Name = pc.Name,
                }).ToList();
            return productCategoryResult;

        }

        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            ProductCategory productCategory = _productCategoryRepository.Get(id);
            ProductCategoryViewModel result = new ProductCategoryViewModel()
            {
                Name = productCategory.Name,
                Id = productCategory.Id
            };
            return result;
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategory)
        {
            ProductCategory productCAtegorDb = _productCategoryRepository.Get(productCategory.Id);
            productCategory.Name = productCAtegorDb.Name;
            _productCategoryRepository.Update(productCAtegorDb);
        }
    }
}

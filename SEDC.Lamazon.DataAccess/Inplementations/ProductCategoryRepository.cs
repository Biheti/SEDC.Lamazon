using SEDC.Lamazon.DataAccess.Context;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Inplementations;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly LamazonDbContext _dbContext;
    public ProductCategoryRepository (LamazonDbContext lamazonDbContex )
    { _dbContext = lamazonDbContex; }
    public void Delete(int id)
    {
        ProductCategory productCategory = _dbContext
            .ProductCategories
            .FirstOrDefault(pc => pc.Id == id);

        _dbContext.ProductCategories.Remove(productCategory);
        _dbContext.SaveChanges();
    }

    public ProductCategory Get(int id)
    {
        ProductCategory productCategory = _dbContext
             .ProductCategories
             .FirstOrDefault(pc => pc.Id == id);
        return productCategory;
    }

    public List<ProductCategory> GetAll()
    {
        List<ProductCategory> productCategories = _dbContext
            .ProductCategories
            .ToList();
        return productCategories;
    }

    public int Insert(ProductCategory productCategory)
    {
          _dbContext 
            .ProductCategories
            .Add(productCategory);

         _dbContext.SaveChanges();

        return productCategory.Id;

    }

    public void Update(ProductCategory productCategory)
    {
       _dbContext 
            .ProductCategories
            .Update(productCategory);

        _dbContext.SaveChanges();
    }
}

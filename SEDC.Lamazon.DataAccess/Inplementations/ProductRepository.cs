using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Context;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Entities;

namespace SEDC.Lamazon.DataAccess.Inplementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly LamazonDbContext _lamazonDbContex;
        public ProductRepository(LamazonDbContext lamazonDbContex)
        {
            _lamazonDbContex = lamazonDbContex;
        }

        public void Delete(int id)
        {
           Product product = _lamazonDbContex
                .Products
                .Where(x => x.Id == id)
                .FirstOrDefault ();

            _lamazonDbContex.Products.Remove (product);

            _lamazonDbContex.SaveChanges ();
        }

        public Product Get(int id)
        {
            Product product = _lamazonDbContex
                .Products
                .Include(x => x.ProductCategory)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            _lamazonDbContex.SaveChanges();
            return product;
        }

        public List<Product> GetAll()
        {
            List<Product> product = _lamazonDbContex
            .Products
            .Include(p => p.ProductCategory)
            .ToList();
            return product;
        }

        public int Insert(Product product)
        {
            _lamazonDbContex.Products.Add(product);

            _lamazonDbContex.SaveChanges();

            return product.Id;
        }

        public void Update(Product product)
        {
            _lamazonDbContex.Products.Update(product);
            _lamazonDbContex.SaveChanges();
        }
    }
}

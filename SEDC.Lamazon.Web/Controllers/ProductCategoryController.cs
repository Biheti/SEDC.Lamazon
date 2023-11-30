using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.ProductCategory;
using System.Runtime.InteropServices;

namespace SEDC.Lamazon.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            List<ProductCategoryViewModel> response = _productCategoryService.GetAllProductCategories();

            return View(response);
        }
        public IActionResult Create() 
        {

            return View();
        }
    }
}

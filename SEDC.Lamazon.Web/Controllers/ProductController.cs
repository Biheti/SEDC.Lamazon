using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.Product;
using SEDC.Lamazon.Services.ViewModels.ProductCategory;

namespace SEDC.Lamazon.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService )
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> productResponse = _productService.GetAllProducts();

            return View(productResponse);
        }

        public IActionResult Create()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            List<ProductCategoryViewModel> productCategories = _productCategoryService.GetAllProductCategories();
            ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");

            return View(createProductViewModel);
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateProductViewModel createProductViewModel )
        {
            try
            { 
               _productService.CreateProduct(createProductViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception) 
            {
                return View("Error");
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.Product;
using SEDC.Lamazon.Web.Models;
using System.Diagnostics;

namespace SEDC.Lamazon.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductViewModel > products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult ProductDetails( int id) 
        {
            var productDetails = _productService.GetProductById(id);
            return View(productDetails);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult UserInfo() 
        {
            return View();
        }
    }
}
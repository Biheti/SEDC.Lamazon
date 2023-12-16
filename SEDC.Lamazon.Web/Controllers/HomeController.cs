using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.Order;
using SEDC.Lamazon.Services.ViewModels.Product;
using SEDC.Lamazon.Web.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SEDC.Lamazon.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;


        public HomeController(ILogger<HomeController> logger, IProductService productService, IOrderService orderService, IOrderItemService orderItemService)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;
            _orderItemService = orderItemService;
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

        [Authorize]
        public IActionResult AddToCart(int productId )
        {
            try 
            {
                string userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int userId = int.Parse(userIdString);

                OrderViewModel activeOrder = _orderService.GetActiveOrder(userId);
                if (activeOrder == null)
                {
                    OrderViewModel orderViewModel = new OrderViewModel()
                    {
                        UserId = userId,
                    };
                    _orderService.CreateOrder(orderViewModel);
                    activeOrder = _orderService.GetActiveOrder(userId);
                }
                _orderItemService.CreateOrderItem(productId, activeOrder.Id);

                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                return View("Error");

            }


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
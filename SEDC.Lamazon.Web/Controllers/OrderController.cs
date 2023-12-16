using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.Order;
using System.Security.Claims;

namespace SEDC.Lamazon.Web.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public  OrderController (IOrderService orderService) 
    {
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ShoppingCart()
    {
        string userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        int userId = int.Parse(userIdString);

        OrderViewModel activeOrderData = _orderService.GetActiveOrder(userId);
        return View(activeOrderData);
    }
}

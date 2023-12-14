using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.ProductCategory;
using System.Runtime.InteropServices;

namespace SEDC.Lamazon.Web.Controllers;

[Authorize(Roles = "Admin")]
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
    [HttpPost]
    public IActionResult Create([FromForm] ProductCategoryViewModel model) 
    {
        try 
        {
            _productCategoryService.CreateProductCategory(model);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            //TODO Error page and logging info
            return View("Error");
        }

    }
}

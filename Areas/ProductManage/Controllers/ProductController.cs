using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

// [Area("ProductManager")]
public class ProductController : Controller
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {

        var products = _productService.OrderBy(p => p.Name).ToList();
        return View(products);
    }
}
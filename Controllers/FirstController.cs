using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FirstController : Controller
    {

        public IWebHostEnvironment _env { get; set; }
        private readonly ProductService _productService;
        public FirstController(IWebHostEnvironment env, ProductService productService)
        {
            _env = env;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bird()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Files", "spring.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }

        public IActionResult Readme()
        {
            var content = @"
                Xin chao cac ban,
                Toi la Thang
            ";

            return Content(content, "text/plain");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    ProductName = "Iphone13 Pro",
                    Price = 24000
                });
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }

        public IActionResult HelloView(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                userName = "admin";
            }
            return View("xinchao2", userName);
        }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                TempData["StatusMessage"] = "Product not found";
                return Redirect(Url.Action("Index", "Home"));
            }
            // cach 1
            // return View(product);

            // ViewData
            // ViewData["product"] = product;
            // return View("ViewProduct2");

            //ViewBag
            ViewBag.product = product;
            return View("ViewProduct3");
        }

        /*
            View() -> razor engine  , doc .cshtml (template)
            -------------------------------------------------------
            View(template) -> duong dan tuyet doi
                View("/MyView/xinchao1.cshtml")

            View(template,model) -> truyen du lieu tu controllers den view 
                View("/MyView/xinchao1.cshtml", userName)
                or
                View("xinchao2", userName)  ->  /View/namecontroler/nameAction

            View()  -> mo template trung ten vs action
                -> /View/namecontroler/nameAction.cshtml
        */
    }
}

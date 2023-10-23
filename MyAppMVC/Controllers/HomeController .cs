using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAppMVC.Models;
using MyAppMVC.ViewModels.HomeViewModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;


namespace MyAppMVC.Controllers
{
    public class HomeController : Controller
    {
        static int _productId = 1;
        private static readonly List<Product> _products = new();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _productId;
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.CreatedDate}");
                _products.Add(product);
                _productId++;

                ModelState.Clear();

                return View("Index");
            }
            else {
                return View("ErrorView");
            }

        }

        public ActionResult ShowProducts(ShowStyles showStyle)
        {
            Console.WriteLine($"old style: {showStyle}");
            ShowProductsViewModel showProductsViewModel = new(_products, showStyle);
            return View(showProductsViewModel);
        }


        [HttpPost]
        public ActionResult ToggleView(string ShowStyle)
        {
            Console.WriteLine($"old style: {ShowStyle}");
            ShowStyles newStyle = ShowStyle == ShowStyles.List.ToString() ? ShowStyles.Table : ShowStyles.List;
            Console.WriteLine($"new style: {newStyle}");
            ShowProductsViewModel showProductsViewModel = new(_products, newStyle);
            return View("ShowProducts", showProductsViewModel);
        }
    }
}
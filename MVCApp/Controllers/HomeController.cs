using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using MVCApp.ViewModels;
using System.Security.Cryptography.Xml;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        static int _userId = 1;
        static int _productId = 1;
        static readonly List<User> _users = new List<User>();
        static readonly List<Product> _products = new List<Product>();

        public IActionResult Index()
        {
            IndexViewModel users = new IndexViewModel(_users);
            return View(users);
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult AddUser(User user)
        {
            Console.WriteLine($"{user.Id}, {user.Name},{user.Password}, {user.AmountOfProducts}");
            if (ModelState.IsValid && user.Age > 16)
            {
                user.Id = _userId;
                _users.Add(user);
                for (int i = 0; i < user.AmountOfProducts; i++)
                {
                    // Product product = new Product();    
                    // product.Id = _productId;
                    // product.User = user;
                    _products.Add(new Product(_productId,user));
                    Console.WriteLine(_products[i].Id);
                    _productId++;
                }
                _userId++;
                return View("Index", new IndexViewModel(_users));
            }
            return View("UnderAge");
        }

       
        public IActionResult ShowUserProducts(User user)
        {
            Console.WriteLine($"User Id: {user.Id}");
            ProductsViewModel products = new ProductsViewModel(
                _products.Where(p => p.User.Id == user.Id).ToList()
                ) ;
            Console.WriteLine($"Count of products: {products.Products.ToList().Count}");
            return View(products);
        }
        
        [HttpPost]
        public IActionResult ChangeProducts(IFormCollection form)
        {
            string newId = form["Id"];
            string newName = form["Name"];
            string newDescription = form["Description"];

            Console.WriteLine($"{newId}, {newName}, {newDescription}" );
            var newProduct = _products.FirstOrDefault(p => p.Id == int.Parse(newId));
            newProduct.Name = newName;
            newProduct.Description = newDescription;

            return View("Index", new IndexViewModel(_users));
        }



        public IActionResult FilterUserByAge(User user)
        {
            List<User> filteredUsers = _users.Where(x => {
                if (user.Age == 0)
                {
                    return true;
                }
                return x.Age == user.Age;
            }).ToList();
            
            return View("Index", new IndexViewModel(filteredUsers));
        }
        
    }
}

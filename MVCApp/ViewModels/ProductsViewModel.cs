using MVCApp.Models;

namespace MVCApp.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel() { }
        public ProductsViewModel(IEnumerable<Product> products)
        {
            Products = products;
        }

        public IEnumerable<Product> Products { get; set; }
        public int Id { get; set; }
    }
}

using MVCApp.Models;

namespace MVCApp.Models
{
    public record class ProductsList (IEnumerable<Product> Products);
 
}

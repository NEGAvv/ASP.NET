using MyAppMVC.Models;
namespace MyAppMVC.ViewModels.HomeViewModel
{
    public enum ShowStyles
    {
        List,
        Table
    }
    public record class ShowProductsViewModel(IEnumerable<Product> Products, ShowStyles ShowStyle);
}

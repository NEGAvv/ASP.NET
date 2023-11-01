using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyAppMVC.Models;
using MyAppMVC.ViewModels.HomeViewModel;
using System.Text;

namespace MyAppMVC.ViewComponents
{
    public class ProductTableViewComponent
    {
        public IViewComponentResult Invoke(Product product)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<li class=\"list-group-item\">{@product.Id}.{@product.Name} - ${@product.Price}({@product.CreatedDate})</li>");
            return new HtmlContentViewComponentResult(new HtmlString(sb.ToString()));
        }
    }
}

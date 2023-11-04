using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MyAppMVC.Models;
using MyAppMVC.ViewModels.HomeViewModel;
using System.Text;

namespace MyAppMVC.ViewComponents
{
    public class ConsultationTableViewComponent
    {
        public IViewComponentResult Invoke(Consultation consultation)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<li class=\"list-group-item\">{consultation.Id}.  {consultation.Name} - {consultation.Email} - {consultation.Subject} - ({consultation.DateOfConsultation.ToString("dd.MM.yyyy")})</li>");
            return new HtmlContentViewComponentResult(new HtmlString(sb.ToString()));
        }
    }
}

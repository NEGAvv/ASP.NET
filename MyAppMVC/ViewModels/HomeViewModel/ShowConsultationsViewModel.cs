using MyAppMVC.Models;

namespace MyAppMVC.ViewModels.HomeViewModel
{
    public enum ShowStyles
    {
        List,
        Table
    }
    public record class ShowConsultationsViewModel(IEnumerable<Consultation> Consultations, ShowStyles ShowStyle);
}

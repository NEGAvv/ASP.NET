using System.ComponentModel.DataAnnotations;

namespace MyAppMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не вказано логін")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка має бути від 3 до 50 символів")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string? RepeatPassword { get; set; }

    }
}

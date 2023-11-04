using MyAppMVC.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace MyAppMVC.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не вказано ім'я")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина рядка має бути від 3 до 50 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не вказана електронна адреса")]
        [EmailAddress(ErrorMessage = "Невірний формат Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некоректна адреса")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказана дата консультації")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата консультації")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "Дата має бути в майбутньому")]
        [WeekdayDate(ErrorMessage = "Дата не може бути вихідним днем")]
        public DateTime DateOfConsultation { get; set; }

        [Required(ErrorMessage = "Не вказано предмет")]
        public string Subject { get; set; }

    }
}

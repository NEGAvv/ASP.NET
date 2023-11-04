using System;
using System.ComponentModel.DataAnnotations;
namespace MyAppMVC.Models.Validators
{
    public class WeekdayDateAttribute : ValidationAttribute
    {
        public WeekdayDateAttribute()
        {
            ErrorMessage = "Дата не може бути вихідним днем (субота або неділя)";
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return false; 
                }
                return true;
            }
            return false;
        }
    }
}

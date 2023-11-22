using MyAppMVCLr12.Models;

namespace MyAppMVCLr12.db
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();


            if (!context.Companies.Any())
            {
                //context.Companies.AddRange(
                //    new Company
                //    {
                //        Name = "Microsoft",
                //        Description = "Технологічна корпорація, яка виробляє програмне забезпечення, апаратне забезпечення та інші продукти."
                //    },
                //    new Company
                //    {
                //        Name = "Tesla",
                //        Description = "Виробник електричних автомобілів, електроенергетичних продуктів та сонячних панелей"
                //    },
                //    new Company
                //    {
                //        Name = "Coca-Cola",
                //        Description = "Одна з найбільших світових компаній, що виробляє безалкогольні напої та інші напої."
                //    },
                //     new Company
                //     {
                //         Name = "Amazon",
                //         Description = "Глобальна торговельна компанія та провідний постачальник послуг хмарного обчислення"
                //     },
                //      new Company
                //      {
                //          Name = "SpaceX",
                //          Description = "Приватна аерокосмічна компанія, заснована Ілоном Маском. Спеціалізується на розробці та запуску ракет для космічних місій та розвитку технологій для заселення Марса."
                //      }
                //);
                //context.SaveChanges();
            }


            if (!context.Users.Any())
            {
                //context.Users.AddRange(
                //    new User { FirstName = "Alina", LastName = "Khudolii", Age = 19 },
                //    new User { FirstName = "Yaroslav", LastName = "Popov", Age = 19 },
                //    new User { FirstName = "Adnrii", LastName = "Yevseev", Age = 20 }
                //);
                //context.SaveChanges();
            }

        }
    }
}

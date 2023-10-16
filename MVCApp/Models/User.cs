using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public  class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Amount Of Products must be a non-negative number")]
        public int AmountOfProducts { get; set; }
        public User() { }
        public User(int id, string name, int age, string password, int amountOfProducts)

        {
            Id = id;
            Name = name;
            Age = age;
            Password = password;
            AmountOfProducts = amountOfProducts;
        }
    }
    
}

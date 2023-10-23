using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace MyAppMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product()
        {
            CreatedDate = DateTime.Now;
        }
    }
}

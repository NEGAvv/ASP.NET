using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCApp.Models
{
    public  class Product
    {
    public int Id { get; set; }
    public User User { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
        public Product(int id, User user)
        {
            Id = id;
            User = user;
            Description = null;
            Name = null;
        }
        public Product(int id,User user, string description, string name)

    {
        Id = id;
        User = user;
        Description = description;
        Name = name;
    }
}
}

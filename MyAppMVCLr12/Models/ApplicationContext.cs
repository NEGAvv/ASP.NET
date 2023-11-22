using Microsoft.EntityFrameworkCore;

namespace MyAppMVCLr12.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)

        {

            Database.EnsureCreated(); // Створюємо базу даних при першому зверненні

        }
    }
}

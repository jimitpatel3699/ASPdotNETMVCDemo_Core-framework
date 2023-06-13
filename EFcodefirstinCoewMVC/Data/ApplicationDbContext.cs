using EFcodefirstinCoewMVC.Models;
using EFcodefirstinCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcodefirstinCoewMVC.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>  Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Programming with c/c++", Author = "E.Balagurusamy", ISBN = "9781234567897", Description = "programming in C book", Price = 350,ImageUrl="",CategoryId=2 },
                new Product { Id = 2, Title = "Programming with C#", Author = "Darly", ISBN = "9781234567667", Description = "programming in C# book", Price = 550, ImageUrl = "", CategoryId = 2 },
                new Product { Id = 3, Title = "Programming with Mosh", Author = "Mosh", ISBN = "9783254567897", Description = "programming in VB book", Price = 450, ImageUrl = "", CategoryId = 2 },
                new Product { Id = 4, Title = "Programming with Java", Author = "A.adly", ISBN = "9781275467897", Description = "programming in Java book", Price = 750, ImageUrl = "", CategoryId = 2 }
                );
        }
    }
}
  
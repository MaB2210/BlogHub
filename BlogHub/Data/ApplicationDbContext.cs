using BlogHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogModel> blogModels { get; set; } 
         public DbSet<CategoryModel> categoryModels { get; set; }
        public DbSet<UserModel> userModels { get; set; }
    }
}
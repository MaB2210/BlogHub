using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace BlogHub.Models
{
    public class BlogModel
    {
        public BlogModel() { }

        public BlogModel(int blogid, String title, String blogdescription, String category, String user)
        {
            BlogId = blogid;
            Title = title;
            BlogDescription = blogdescription;
            Category = category;
            User = user;
        }
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string BlogDescription { get; set; }
        public string Category { get; set; }
        public string User { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public UserModel UserModel { get; set; }

        public CategoryModel CategoryModel { get; set; }

    }
}

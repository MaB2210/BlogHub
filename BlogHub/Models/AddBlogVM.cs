using System.ComponentModel.DataAnnotations;

namespace BlogHub.Models
{
    public class AddBlogVM
    {
        
      
        
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

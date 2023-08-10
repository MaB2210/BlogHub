using System.ComponentModel.DataAnnotations;

namespace BlogHub.Models
{
    public class CategoryModel
    {
        public CategoryModel() { }

        public CategoryModel(int categoryid, String name, String categorydescription)
        {
            CategoryId = categoryid;
            Name = name;
            CategoryDescription = categorydescription;
        }
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryDescription { get; set; }

        public List<BlogModel> Blog { get; set; }

    }
}

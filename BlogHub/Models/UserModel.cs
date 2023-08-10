using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace BlogHub.Models
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(int userid, String username, String email, String contactno, String country)
        {
            Userid = userid;
            Username = username;
            Email = email;
            Contactno = contactno;
            Country = country;
        }
        [Key]
        public int Userid { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String Contactno { get; set; }
        public String Country { get; set; }

        public List<BlogModel> Blog { get; set; }
    }
}

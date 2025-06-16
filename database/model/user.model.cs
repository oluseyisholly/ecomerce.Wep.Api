using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

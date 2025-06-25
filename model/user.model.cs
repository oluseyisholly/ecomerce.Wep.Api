using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class User : Base
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [MaxLength(255)]
        public string? PasswordHash { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = null!;
        public ICollection<Cart> Carts { get; set; } = null!;
        public ICollection<ShippingAddress> ShippingAddresses { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace EcommerceWebApi.Dto
{
    public class CreateUserDto : LoginDto
    {
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
    }

    public class LoginDto
    {
        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }

    public class UpdateUserDto : CreateUserDto { }
}

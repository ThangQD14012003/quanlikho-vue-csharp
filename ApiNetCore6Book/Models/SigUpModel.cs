using System.ComponentModel.DataAnnotations;

namespace ApiNetCore6Book.Models
{
    public class SigUpModel
    {
        // 2 cái dưới lấy từ ApplicationUser
        [Required]
        public string FirstName { get; set; } = null!; // cho phep null
        [Required]

        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}

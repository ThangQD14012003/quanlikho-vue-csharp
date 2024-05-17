using Microsoft.AspNetCore.Identity;

namespace ApiNetCore6Book.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!; // cho phep null

        public string LastName { get; set; } = null!;
    }
}

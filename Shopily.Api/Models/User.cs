using Microsoft.AspNetCore.Identity;

namespace Shopily.Api.Models
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        
    }
    
}

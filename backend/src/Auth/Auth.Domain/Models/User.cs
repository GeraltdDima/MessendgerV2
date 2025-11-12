using Microsoft.AspNetCore.Identity;
using Shared.Domain.Models;

namespace Auth.Domain.Models
{
    public class User : IdentityUser, IBaseEntity<User, string>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public void Update(User source)
        {
            UserName = source.UserName;
            Email = source.Email;
        }

        public string GetString() => $"User:{Id}";
    }
}
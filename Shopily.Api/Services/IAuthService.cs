using Microsoft.AspNetCore.Identity;
using Shopily.Api.RequestsResponses;

namespace Shopily.Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(AuthRequest model);
        Task<IdentityResult> RegisterAsync(RequestsResponses.RegisterRequest model);
        Task<IdentityResult> UpdateProfileAsync(string userId, UpdateProfileRequest model);
        Task<GetUserRequestResponse?> GetUserByIdAsync(string userId);
    }
}

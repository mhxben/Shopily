using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shopily.Api.Models;
using Shopily.Api.RequestsResponses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shopily.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<GetUserRequestResponse?> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            return new GetUserRequestResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
        }

        public async Task<AuthResponse?> LoginAsync(AuthRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return null;

            var token = GenerateJwtToken(user);
            return new AuthResponse { Token = token, UserId = user.Id, FirstName = user.FirstName };
        }

        public async Task<IdentityResult> RegisterAsync(RegisterRequest model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                PhoneNumber = model.PhoneNumber
            };
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<IdentityResult> UpdateProfileAsync(string userId, UpdateProfileRequest model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            // Update Full Name
            if (!string.IsNullOrEmpty(model.FirstName))
                user.FirstName = model.FirstName;

            if (!string.IsNullOrEmpty(model.LastName))
                user.LastName = model.LastName;

            // Update Email
            if (!string.IsNullOrEmpty(model.Email))
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null && existingUser.Id != user.Id)
                    return IdentityResult.Failed(new IdentityError { Description = "Email already in use" });

                user.Email = model.Email;
                user.UserName = model.Email; // Ensure email-based username consistency
            }

            // Update Phone Number
            if (!string.IsNullOrEmpty(model.PhoneNumber))
                user.PhoneNumber = model.PhoneNumber;

            if (!string.IsNullOrEmpty(model.Role))
                user.Role = model.Role;

            // Update Password (if provided)
            if (!string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                var checkPassword = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
                if (!checkPassword)
                    return IdentityResult.Failed(new IdentityError { Description = "Current password is incorrect" });

                var passwordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordResult.Succeeded)
                    return passwordResult;
            }

            return await _userManager.UpdateAsync(user);
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

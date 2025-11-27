using MagazinFigurineApp.Models;
using MagazinFigurineApp.Services.Intefaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace MagazinFigurineApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Utilizator> _userManager;
        private readonly SignInManager<Utilizator> _signInManager;
        public AuthService(UserManager<Utilizator> userManager, SignInManager<Utilizator> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(string email, string password)
        {
            var user = new Utilizator { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Verifică dacă rolul există, apoi adaugă userul în rol
                if (!await _userManager.IsInRoleAsync(user, "User"))
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

            return result;
        }
        public async Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            return (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<(bool succeeded, bool requires2FA, bool isLockedOut, string errorMessage)> LoginAsync(string email, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
                return (true, false, false, null);

            if (result.RequiresTwoFactor)
                return (false, true, false, null);

            if (result.IsLockedOut)
                return (false, false, true, null);

            return (false, false, false, "Invalid login attempt.");
        }
    }
}
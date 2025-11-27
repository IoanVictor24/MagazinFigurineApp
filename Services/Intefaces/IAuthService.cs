using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(string email, string password);
        Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<(bool succeeded, bool requires2FA, bool isLockedOut, string errorMessage)> LoginAsync(string email, string password, bool rememberMe);

    }
}

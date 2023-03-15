using Restock.Models;

namespace Restock.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshAsync(string token, string refreshToken);
    }
}

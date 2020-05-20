using System.Threading.Tasks;

namespace Cooper.MotCheck.Services
{
    public interface ITokenService : IServiceAuthenticationProvider
    {
        string GetTokenRequestRedirectUri();
        Task RequestToken(string code);
    }
}

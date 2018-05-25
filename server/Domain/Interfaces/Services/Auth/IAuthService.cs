using Domain.Responses.Auth;

namespace Domain.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        AuthResponse GetJWTToken(string claimValue);
    }
}
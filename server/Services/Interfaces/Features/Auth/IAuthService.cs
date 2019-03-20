using Entities.Responses.Auth;

namespace Services.Interfaces.Features.Auth
{
    public interface IAuthService
    {
        AuthResponse GetJWTToken(string claimValue);
    }
}
using Services.Interfaces.Features.Auth;
using Entities.Responses.Auth;
using Services.Features.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Features.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IAppSettingsServices _appSettings;

        public AuthService(IAppSettingsServices appSettings)
        {
            _appSettings = appSettings;
        }

        public IAppSettingsServices AppSettings { get; }

        public AuthResponse GetJWTToken(string claimValue)
        {
            AuthResponse response = new AuthResponse();

            if (string.IsNullOrWhiteSpace(claimValue))
            {
                response.AddErrorMessage("Valor da claim não recebido");
                return response;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, claimValue)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Key = tokenHandler.WriteToken(token);

            return response;
        }
    }
}
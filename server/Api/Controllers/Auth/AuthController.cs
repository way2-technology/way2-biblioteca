using Domain.Interfaces.Services.Auth;
using Domain.Responses.Auth;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers.Auth
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public AuthResponse Authenticate() =>
           _authService.GetJWTToken(Guid.NewGuid().ToString());
    }
}
using System;
using Entities.Responses.Auth;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Features.Auth;

namespace Api.Controllers.Auth {
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
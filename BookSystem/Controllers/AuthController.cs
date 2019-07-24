using System;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookSystem.Controllers {
    [Route("api/auth")]
    public class AuthController : Controller {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;
        private readonly IAuthenticationServices _authenticationServices;

        public AuthController(IAuthenticationServices authenticationServices, IConfiguration configuration, IUserServices userServices) {
            _configuration = configuration;
            _userServices = userServices;
            _authenticationServices = authenticationServices;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginDto loginData) {
            IActionResult response = Unauthorized();
            var loginUser = _authenticationServices.Authentication(loginData);
            if (loginUser != null) {
                var tokenString = _authenticationServices.GenerateJsonWebToken(loginUser);
                loginUser.Token = tokenString;
                response = Ok(loginUser);
            }

            return response;
        }
    }
}
using System;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookSystem.Controllers {
    [Route("api/auth")]
    public class AuthController : Controller {
        #region Properties

        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;
        private readonly IAuthenticationServices _authenticationServices;

        #endregion

        public AuthController(IAuthenticationServices authenticationServices, IConfiguration configuration, IUserServices userServices) {
            _configuration = configuration;
            _userServices = userServices;
            _authenticationServices = authenticationServices;
        }

        #region API Declaration

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginDto loginData) {
            IActionResult response = Unauthorized();
            var loginUser = _authenticationServices.Authenticate(loginData);
            if (loginUser != null) {
                var tokenString = _authenticationServices.GenerateJsonWebToken(loginUser);
                loginUser.Token = tokenString;
                response = Ok(loginUser);
            }

            return response;
        }
        
        [Authorize(Roles = "Admin, User")]
        [HttpPost("logout")]
        public IActionResult Logout() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
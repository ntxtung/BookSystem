using System;
using BookSystem.Entities;
using BookSystem.Entities.DataTransferObject;
using BookSystem.Helpers.ExceptionHelper;
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
        [HttpPost("register")]
        public IActionResult RegisterNewUser([FromBody] Users userData) {
            try {
                var result = _userServices.PostUser(userData);
                if (result > 0) {
                    var loggedUser = _authenticationServices.FindUser(new LoginDto{Username = userData.Username, Password = userData.Password});
                    loggedUser.Token = _authenticationServices.GenerateJsonWebToken(loggedUser);
                    return CreatedAtRoute(
                        "UserLink",
                        new {id = userData.Id},
                        loggedUser
                    );
                }
            }
            catch (DuplicateEntryException) {
                return BadRequest(new {
                    message = "Duplicated Entry"
                });
            }
            catch (Exception) {
                return BadRequest(new {
                    message = "Unhandled Exception"
                });
            }

            return BadRequest(new {
                message = "Register Unsuccessfully"
            });
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginDto loginData) {
            IActionResult response = Unauthorized();
            var loginUser = _authenticationServices.FindUser(loginData);
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
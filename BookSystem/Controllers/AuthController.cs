using System;
using BookSystem.Entities;
using BookSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.Controllers {
    [Route("api/auth")]
    public class AuthController : Controller {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices) {
            _userServices = userServices;
        }

        [HttpPost("login")]
        public IActionResult Authenticate(string username, string password) {
            return Ok(_userServices.Authenticate(username, password));
        }
    }
}
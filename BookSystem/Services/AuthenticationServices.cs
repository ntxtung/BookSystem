using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BookSystem.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookSystem.Services {
    public class AuthenticationServices : IAuthenticationServices {
        private readonly BookSystemContext _context;
        private readonly IConfiguration _configuration;
        

        public AuthenticationServices(IConfiguration configuration) {
            _context = new BookSystemContext();
            _configuration = configuration;
        }

        public int GetCurrentUserId(HttpContext httpContext) {
            return Convert.ToInt32(httpContext.User.FindFirst("Id")?.Value);
        }

        public string GenerateJsonWebToken(FullUsersDto userInfo)  
        {  
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Console.WriteLine("HELLO DEBUG: " + userInfo.Role);
            var claims = new[] {  
                new Claim("Id", userInfo.Id.ToString()),
                new Claim("Username", userInfo.Username),  
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.Role == 0 ? "Admin" : "User")
            };  
            
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],  
                _configuration["Jwt:Issuer"],  
                claims,
                expires: DateTime.Now.AddMinutes(120),  
                signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }  

        public FullUsersDto Authentication(LoginDto loginData) {
            var loginUser = _context.Users.SingleOrDefault(user => user.Username == loginData.Username && user.Password == loginData.Password);
            if (loginUser == null)
                return null;
            return new FullUsersDto {
                Id = loginUser.Id,
                Username = loginUser.Username,
                Firstname = loginUser.Firstname,
                Lastname = loginUser.Lastname,
                Email = loginUser.Email,
                Password = null,
                Token = null,
                Avatar = loginUser.Avatar,
                Role = loginUser.Role
            };
        }
    }
}
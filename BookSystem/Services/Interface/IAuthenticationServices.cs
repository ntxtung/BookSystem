using System.Net.Http;
using BookSystem.Entities;
using Microsoft.AspNetCore.Http;

namespace BookSystem.Services {
    public interface IAuthenticationServices {
        int GetCurrentUserId(HttpContext httpContext);
        string GenerateJsonWebToken(FullUsersDto userInfo);
        FullUsersDto Authentication(LoginDto loginData);
    }
}
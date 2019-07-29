using BookSystem.WebApi.Dtos;
using Microsoft.AspNetCore.Http;

namespace BookSystem.Application.UseCase.Authentication {
    public interface IAuthenticationServices {
        int GetCurrentUserId(HttpContext httpContext);
        string GenerateJsonWebToken(FullUsersDto userInfo);
        FullUsersDto FindUser(LoginDto loginData);
    }
}
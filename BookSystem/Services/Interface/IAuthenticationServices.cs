using BookSystem.Entities.DataTransferObject;
using Microsoft.AspNetCore.Http;

namespace BookSystem.Services {
    public interface IAuthenticationServices {
        int GetCurrentUserId(HttpContext httpContext);
        string GenerateJsonWebToken(FullUsersDto userInfo);
        FullUsersDto FindUser(LoginDto loginData);
    }
}
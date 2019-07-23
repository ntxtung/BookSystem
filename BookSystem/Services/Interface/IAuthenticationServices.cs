using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IAuthenticationServices {
        string GenerateJSONWebToken(FullUsersDTO userInfo);
        FullUsersDTO Authentication(LoginDto loginData);
    }
}
using System.Linq;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;

namespace BookSystem.Application.UseCase.UserAccount {
    public interface IUserAccountServices {
        BasicUsersDto GetBasicUserById(int id);
        FullUsersDto GetFullUserById(int id);
        IQueryable GetUsers(int page=1, int pageSize=5);
        int RegisterNewUser(Users user);
        int UpdateUserInformation(int id, Users newUser);
        int DeleteUser(int id);
    }
}
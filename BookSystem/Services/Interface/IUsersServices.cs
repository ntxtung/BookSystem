using System.Linq;
using BookSystem.Entities;
using BookSystem.Entities.DataTransferObject;

namespace BookSystem.Services {
    public interface IUserServices {
        BasicUsersDto GetBasicUserById(int id);
        FullUsersDto GetFullUserById(int id);
        IQueryable GetUsers(int page=1, int pageSize=5);
        IQueryable GetFundedBookOfUser(int id, int page=1, int pageSize=5);
        IQueryable GetRentedBookOfUser(int id, int page=1, int pageSize=5);
        int PostUser(Users user);
        int PutUser(int id, Users newUser);
        int DeleteUser(int id);
    }
}
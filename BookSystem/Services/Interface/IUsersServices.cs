using System;
using System.Collections;
using System.Linq;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IUserServices {
        BasicUsersDTO GetUserById(int id);
        IQueryable GetUsers();
        IQueryable GetFundedBookOfUser(int id);
        IQueryable GetRentedBookOfUser(int id);
        FullUsersDTO Authenticate(string username, string password);
        int PostUser(Users user);
        int PutUser(int id, Users newUser);
        int DeleteUser(int id);
    }
}
using System;
using System.Collections;
using System.Linq;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IUserServices {
        BasicUsersDTO GetBasicUserById(int id);
        FullUsersDto GetFullUserById(int id);
        IQueryable GetUsers();
        IQueryable GetFundedBookOfUser(int id);
        IQueryable GetRentedBookOfUser(int id);
        int PostUser(Users user);
        int PutUser(int id, Users newUser);
        int DeleteUser(int id);
    }
}
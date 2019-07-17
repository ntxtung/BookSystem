using System;
using System.Collections;
using System.Collections.Generic;
using BookSystem.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookSystem.Services {
    public interface IUserServices {
        Object GetUserById(int id);
        IList GetAllUsers();
        IList GetFundedBookOfUser(int id);
        IList GetRentedBookOfUser(int id);
        Object Authenticate(string username, string password);
        int RegisterNewUser(Users user);
        int UpdateUser(int id, Users newUser);
        int DeleteUser(int id);
    }
}
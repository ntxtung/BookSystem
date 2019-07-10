using System.Collections.Generic;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IUserServices {
        // Return a User by finding its Id
        Users GetUserById(int id);

        // Just return all users
        List<Users> GetAllUsers();

        // Create new user and save it to database
        int RegisterNewUser(Users user);

        // Update a user (Find by Id) and update its properties due to newUser properties
        int UpdateUser(int id, Users newUser);

        // Delete User (Find by Id), then should delete all funded book as well, update User_Request_Book as well
        int DeleteUser(int id);
    }
}
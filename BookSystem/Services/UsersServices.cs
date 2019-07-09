using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BookSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Services {
    public class UsersServices : IUserServices {
        private readonly BookSystemContext _context;
        private readonly DbSet<Users> _userContext;

        public UsersServices() {
            _context = new BookSystemContext();
            _userContext = _context.Users;
        }

        /// <summary>
        /// Get User by finding its Id
        /// </summary>
        /// <param name="id">Id of User</param>
        /// <returns>User object</returns>
        public Users GetUserById(int id) {
            return _userContext.SingleOrDefault(user => user.Id == id);
        }

        /// <summary>
        /// Return List of all users
        /// </summary>
        /// <returns>List object that contains all users</returns>
        public List<Users> GetAllUsers() {
            try {
                return _userContext.ToList();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Create new user and save to database
        /// </summary>
        /// <param name="user">User object that want to save to DB</param>
        /// <returns>0 when update failed</returns>
        /// <returns>1 or larger when update success</returns>
        public int RegisterNewUser(Users user) {
            try {
                _userContext.Add(user);
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbce) {
                Console.WriteLine("DbUpdateConcurrency Exception: " + dbce);
            }
            catch (DbUpdateException dbe) {
                Console.WriteLine("DbUpdateException: " + dbe);
            }

            return 0;
        }

        /// <summary>
        /// Update user (Find by id) then update it to object newUser
        /// </summary>
        /// <param name="id">Id of User want to update</param>
        /// <param name="newUser">New User properties</param>
        /// <returns>Nah?</returns>
        public int UpdateUser(int id, Users newUser) {
            try {
                var oldUser = _userContext.First(user => user.Id == id);
                throw new System.NotImplementedException();
                Console.WriteLine("Id: {0}, Username: {1}, Firstname: {2}, Password: {3}", oldUser.Id, oldUser.Username, oldUser.Firstname, oldUser.Password);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                Console.WriteLine("Update Exception: " + dbe);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            return 0;
        }
        
        public int DeleteUser(int id) {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Linq;
using BookSystem.Application.Handler;
using BookSystem.Application.Helpers;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Application.UseCase.UserAccount {
    public class UserAccountServices : IUserAccountServices {
        private readonly BookSystemContext _context;
        private readonly UserHelper _userHelper;

        public UserAccountServices() {
            _context = new BookSystemContext();
            _userHelper = new UserHelper();
        }

        public BasicUsersDto GetBasicUserById(int id) {
            return new BasicUsersDto(_userHelper.FindUserById(id));
        }

        public FullUsersDto GetFullUserById(int id) {
            return new FullUsersDto(_userHelper.FindUserById(id));
        }

        public IQueryable GetUsers(int page = 1, int pageSize = 5) {
            return _context.Users
                .Select(user => new FullUsersDto(user))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
        
    #warning Refactor this to RegisterDto
        public int RegisterNewUser(Users user) {
            try {
                _context.Users.Add(user);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                var handler = new DbUpdateExceptionHandler(dbe);
                handler.DoHandle();
            }

            return -1;
        }

        public int UpdateUserInformation(int id, Users newUser) {
            throw new NotImplementedException();
        }

        public int DeleteUser(int id) {
            throw new NotImplementedException();
        }
    }
}
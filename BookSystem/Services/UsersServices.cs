using System;
using System.Linq;
using BookSystem.Entities;
using BookSystem.Entities.DataTransferObject;
using BookSystem.Helpers.ExceptionHelper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Services {
    public class UsersServices : IUserServices {
        private readonly BookSystemContext _context;
        private readonly DbSet<Users> _userContext;
        
        public UsersServices() {
            _context = new BookSystemContext();
            _userContext = _context.Users;
        }

        public BasicUsersDto GetBasicUserById(int id) {
            try {
                return _userContext.Select(user => new BasicUsersDto(user)).Single(user => user.Id == id);
            }
            catch (InvalidOperationException) {
                throw new Exception("No element found");
            }
        }
        
        public FullUsersDto GetFullUserById(int id) {
            try {
                return _userContext
                    .Select(user => new FullUsersDto(user))
                    .Single(user => user.Id == id);
            }
            catch (InvalidOperationException) {
                throw new Exception("No element found");
            }
        }

        public IQueryable GetUsers(int page=1, int pageSize=5) {
            try {
                return _userContext
                    .Select(user => new FullUsersDto(user))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public IQueryable GetFundedBookOfUser(int id, int page=1, int pageSize=5) {
            return _context.Books
                .Where(book => book.UsersFundId == id)
                .Select(book => new FullBooksDto(book))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable GetRentedBookOfUser(int id, int page=1, int pageSize=5) {
            return _context.Books
                .Where(book => book.UsersRentId == id)
                .Select(book => new FullBooksDto(book))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public int PostUser(Users user) {
            try {
                _userContext.Add(user);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe)
            {
                var mysqlEx = dbe.InnerException as MySqlException;
                if (mysqlEx == null) return 0;
                switch (mysqlEx.Number)
                {
                    case 1062:
                        throw new DuplicateEntryException();
                    default:
                        throw new Exception();
                }
            }
        }

        public int PutUser(int id, Users newUser)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
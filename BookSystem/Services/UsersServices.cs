using System;
using System.Linq;
using BookSystem.Entities;
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

        public BasicUsersDTO GetBasicUserById(int id) {
            try {
                return _userContext.Select(user => new BasicUsersDTO {
                    Id = user.Id,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Avatar = user.Avatar
                }).Single(user => user.Id == id);
            }
            catch (InvalidOperationException) {
                throw new Exception("No element found");
            }
        }
        
        public FullUsersDto GetFullUserById(int id) {
            try {
                return _userContext.Select(user => new FullUsersDto {
                    Id = user.Id,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    Password = null,
                    Token = null,
                    Avatar = user.Avatar
                }).Single(user => user.Id == id);
            }
            catch (InvalidOperationException) {
                throw new Exception("No element found");
            }
        }

        public IQueryable GetUsers(int? page=1, int? pageSize=5) {
            try {
                return _userContext
                    .Select(user => new FullUsersDto {
                        Id = user.Id,
                        Username = user.Username,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        Password = null,
                        Token = user.Token,
                        Avatar = user.Avatar
                    }).Skip((int) ((page - 1) * pageSize)).Take((int) pageSize);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public IQueryable GetFundedBookOfUser(int id, int? page=1, int? pageSize=5) {
            return _context.Books
                .Where(book => book.UsersFundId == id)
                .Select(book => new FullBooksDTO {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Image = book.Image
                }).Skip((int) ((page - 1) * pageSize)).Take((int) pageSize);
        }

        public IQueryable GetRentedBookOfUser(int id, int? page=1, int? pageSize=5) {
            return _context.Books
                .Where(book => book.UsersRentId == id)
                .Select(book => new FullBooksDTO {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Image = book.Image
                }).Skip((int) ((page - 1) * pageSize)).Take((int) pageSize);
        }

        public int PostUser(Users user) {
            try {
                _userContext.Add(user);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                var mysqlEx = dbe.InnerException as MySqlException;
                if (mysqlEx == null) return 0;
                switch (mysqlEx.Number) {
                    case 1062:
                        throw new DuplicationEntryException();
                    default:
                        throw new Exception();
                }
            }
        }

        public int PutUser(int id, Users newUser) {
            throw new NotImplementedException();
        }

        public int DeleteUser(int id) {
            throw new NotImplementedException();
        }
    }
}
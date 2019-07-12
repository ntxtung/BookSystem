using System;
using System.Collections;
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

        private IQueryable<Object> GetUserView() {
            return _userContext.Select(user => new {
                user.Id,
                user.Username,
                user.Firstname,
                user.Lastname,
                user.Email,
                user.Token
            });
        }

        public Object GetUserById(int id) {
            try {
                return _userContext.Select(user => new {
                    user.Id,
                    user.Username,
                    user.Firstname,
                    user.Lastname,
                    user.Email,
                    user.Token
                }).Single(user => user.Id == id);
            }
            catch (InvalidOperationException) {
                throw new Exception("No element found");
            }
        }

        public IList GetAllUsers() {
            try {
                return _userContext
                    .Select(user => new {
                        user.Id,
                        user.Username,
                        user.Firstname,
                        user.Lastname,
                        user.Email,
                        user.Token
                    })
                    .ToList();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public IList GetFundedBookOfUser(int id) {
            return _context.Books
                .Where(book => book.UsersFundId == id)
                .Select(book => new {
                    book.Id,
                    book.Image,
                    book.Title
                }).ToList();
        }

        public IList GetRentedBookOfUser(int id) {
            return _context.Books
                .Where(book => book.UsersRentId == id)
                .Select(book => new {
                    book.Id,
                    book.Image,
                    book.Title
                }).ToList();
        }

        public Object Authenticate(string username, string password) {
            try {
                return _userContext
                    .Select(user => new {
                        user.Id,
                        user.Username,
                        user.Firstname,
                        user.Lastname,
                        user.Email,
                        user.Password,
                        user.Token
                    })
                    .Single(user => user.Username == username && user.Password == password);
            }
            catch (InvalidOperationException) {
                return null;
            }
        }

        public int RegisterNewUser(Users user) {
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

        public int UpdateUser(int id, Users newUser) {
            throw new NotImplementedException();
        }

        public int DeleteUser(int id) {
            throw new NotImplementedException();
        }
    }
}
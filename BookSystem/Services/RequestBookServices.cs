using System;
using System.Collections;
using System.Linq;
using BookSystem.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Services {
    public class RequestBookServices : IRequestBookServices {
        private readonly BookSystemContext _context;

        public RequestBookServices() {
            _context = new BookSystemContext();
        }

        public int DoRequest(int userId, int bookId) {
            try {
                _context.UserRequestBook.Add(new UserRequestBook {
                    UserId = userId,
                    BookId = bookId
                });
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                var mysqlEx = dbe.InnerException as MySqlException;
                if (mysqlEx == null) throw new Exception();
                switch (mysqlEx.Number) {
                    case 1062:
                        throw new DuplicationEntryException();
                    default:
                        throw new Exception();
                }
            }
        }

        public int DoApprove(int userId, int bookId) {
            throw new NotImplementedException();
        }

        public int DoNotApprove(int userId, int bookId) {
            throw new NotImplementedException();
        }

        public IQueryable GetAllBooksUserDidRequest(int userId) {
            return _context.UserRequestBook
                .Where(request => request.UserId == userId)
                .Select(request =>
                    _context.Books
                        .Select(book => new FullBooksDTO {
                            Id = book.Id,
                            Image = book.Image,
                            Title = book.Title
                        })
                        .Single(book => book.Id == request.BookId)
                );
        }

        public IQueryable GetAllUsersWhoRequestBook(int bookId) {
            return _context.UserRequestBook
                .Where(request => request.BookId == bookId)
                .Select(request =>
                    _context.Users
                        .Select(user => new BasicUsersDTO {
                            Id = user.Id,
                            Username = user.Username,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            Avatar = user.Avatar
                        })
                        .Single(user => user.Id == request.UserId)
                );
        }
    }
}
using System;
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
            var rentedBook = _context.Books.Find(bookId);
            if (rentedBook != null) {
                rentedBook.UsersRentId = userId;
                return _context.SaveChanges();
            }

            return -1;
        }

        public int DoNotApprove(int userId, int bookId) {
            throw new NotImplementedException();
        }

        public IQueryable GetAllBooksUserDidRequest(int userId, int? page=1, int? pageSize=5) {
            return _context.UserRequestBook
                .Where(request => request.UserId == userId)
                .Select(request =>
                    _context.Books
                        .Select(book => new FullBooksDto(book))
                        .Single(book => book.Id == request.BookId)
                )
                .Skip((int) ((page - 1) * pageSize))
                .Take((int) pageSize);
        }

        public IQueryable GetAllUsersWhoRequestBook(int bookId, int? page=1, int? pageSize=5) {
            return _context.UserRequestBook
                .Where(request => request.BookId == bookId)
                .Select(request =>
                    _context.Users
                        .Select(user => new BasicUsersDTO(user))
                        .Single(user => user.Id == request.UserId)
                ).Skip((int) ((page - 1) * pageSize)).Take((int) pageSize);
        }
    }
}
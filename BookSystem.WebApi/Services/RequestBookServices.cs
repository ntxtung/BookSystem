using System;
using System.Linq;
using BookSystem.Entities;
using BookSystem.WebApi.Dtos;
using BookSystem.WebApi.Helpers.ExceptionHandler;
using BookSystem.WebApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.WebApi.Services {
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
                new DbUpdateExceptionHandler(dbe).DoHandle();
            }

            return -1;
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

        public IQueryable GetAllBooksUserDidRequest(int userId, int page=1, int pageSize=5) {
            return _context.UserRequestBook
                .Where(request => request.UserId == userId)
                .Select(request =>
                    _context.Books
                        .Select(book => new FullBooksDto(book))
                        .Single(book => book.Id == request.BookId)
                )
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable GetAllUsersWhoRequestBook(int bookId, int page=1, int pageSize=5) {
            return _context.UserRequestBook
                .Where(request => request.BookId == bookId)
                .Select(request =>
                    _context.Users
                        .Select(user => new BasicUsersDto(user))
                        .Single(user => user.Id == request.UserId)
                )
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
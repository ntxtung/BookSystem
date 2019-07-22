using System;
using System.Collections;
using System.Linq;
using BookSystem.Entities;

namespace BookSystem.Services {
    public class RequestBookServices : IRequestBookServices {
        private readonly BookSystemContext _context;

        public RequestBookServices() {
            _context = new BookSystemContext();
        }

        public int DoRequest(int userId, int bookId) {
           var userBook = _context.UserRequestBook.Find(bookId, userId);
           if (userBook != null) return -1;
           _context.UserRequestBook.Add(new UserRequestBook {
               UserId = userId,
               BookId = bookId
           });
           _context.SaveChanges();
           return 0;
        }

        public int DoApprove(int userId, int bookId) {
            throw new NotImplementedException(); 
        }

        public int DoNotApprove(int userId, int bookId) {
            throw new NotImplementedException();
        }

        public IQueryable GetAllBooksUserDidRequest(int userId) {
            throw new NotImplementedException();
        }

        public IQueryable GetAllUsersWhoRequestBook(int bookId) {
            return _context.UserRequestBook
                .Where(book => book.BookId == bookId)
                .Select(request =>
                    _context.Users
                        .Where(user => user.Id == request.UserId)
                        .Select(user => new BasicUsersDTO {
                            Id = user.Id,
                            Username = user.Username,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            Avatar = user.Avatar
                        })
                );
        }
    }
}
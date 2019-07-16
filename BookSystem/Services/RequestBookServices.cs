using System;
using System.Collections;
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

        public IList GetAllRequester(int bookId) {
            throw new NotImplementedException();
        }
    }
}
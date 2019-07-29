using System.Linq;
using BookSystem.Application.Handler;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Application.UseCase.BookManagement {
    public class BookManagement : IBookManagement {
        private readonly BookSystemContext _context;
        
        public BookManagement() {
            _context = new BookSystemContext();
        }

        public FullBooksDto GetBookById(int id) {
            return _context.Books.Select(book => new FullBooksDto(book)).Single(book => book.Id == id);
        }

        public IQueryable GetBooks(int page = 1, int pageSize = 5) {
            return _context.Books.Select(books => new FullBooksDto(books))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public int PostBooks(Books book) {
            try {
                _context.Books.Add(book);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                var handler = new DbUpdateExceptionHandler(dbe);
                handler.DoHandle();
            }
            return -1;
        }

        public int PutBooks(int id, Books newBook) {
            throw new System.NotImplementedException();
        }

        public int DeleteBooks(int id) {
            throw new System.NotImplementedException();
        }

        public BasicUsersDto GetRentedUser(int id) {
            var bookObj = _context.Books.Single(book => book.Id == id);
            return _context.Users.Select(user => new BasicUsersDto(user))
                .Single(user => user.Id == bookObj.UsersRentId);
        }

        public BasicUsersDto GetFundedUser(int id) {
            var bookObj = _context.Books.Single(book => book.Id == id);
            return _context.Users.Select(user => new BasicUsersDto (user))
                .Single(user => user.Id == bookObj.UsersFundId);
        }
    }
}
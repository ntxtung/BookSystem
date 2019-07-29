using System;
using System.Linq;
using BookSystem.Application.Exception;
using BookSystem.Application.Handler;
using BookSystem.Application.Services.Interface;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Application.Services {
    public class BooksServices : IBooksServices {
        private readonly DbSet<Books> _bookContext;
        private readonly BookSystemContext _context;

        public BooksServices() {
            _context = new BookSystemContext();
            _bookContext = _context.Books;
        }
        
        public IQueryable GetBooks(int page=1, int pageSize=10) {
            return _bookContext.Select(books => new FullBooksDto(books))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public FullBooksDto GetBookById(int id) {
            try {
                return _bookContext.Select(book => new FullBooksDto(book)).Single(book => book.Id == id);

            }
            catch (InvalidOperationException e) {
                throw new System.Exception(e.Message);
            }
        }

        public BasicUsersDto GetRentedUser(int id) {
            var bookObj = _bookContext.Single(book => book.Id == id);
            return _context.Users.Select(user => new BasicUsersDto(user))
                .Single(user => user.Id == bookObj.UsersRentId);
        }
        
        public BasicUsersDto GetFundedUser(int id) {
            var bookObj = _bookContext.Single(book => book.Id == id);
            return _context.Users.Select(user => new BasicUsersDto (user))
                .Single(user => user.Id == bookObj.UsersFundId);
        }

        public int PostBooks(Books book) {
            try {
                _bookContext.Add(book);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                var handler = new DbUpdateExceptionHandler(dbe);
                handler.DoHandle();
            }
            return 0;
        }

        public int PutBooks(int id, Books newBook) {
            throw new NotImplementedException();
        }

        public int DeleteBooks(int id) {
            throw new NotImplementedException();
        }
    }
}
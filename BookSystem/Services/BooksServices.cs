using System;
using System.Linq;
using BookSystem.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BookSystem.Services {
    public class BooksServices : IBooksServices {
        private readonly DbSet<Books> _bookContext;
        private readonly BookSystemContext _context;

        public BooksServices() {
            _context = new BookSystemContext();
            _bookContext = _context.Books;
        }
        
        public IQueryable GetBooks(int? page=1, int? pageSize=10) {
            return _bookContext.Select(books => new FullBooksDTO {
                Id = books.Id,
                Title = books.Title,
                Author = books.Author,
                Image = books.Image
            }).Skip((int) ((page - 1) * pageSize)).Take((int) pageSize);
        }

        public FullBooksDTO GetBookById(int id) {
            try {
                return _bookContext.Select(book => new FullBooksDTO {
                    Id = book.Id,
                    Image = book.Image,
                    Title = book.Title
                }).Single(book => book.Id == id);

            }
            catch (InvalidOperationException e) {
                throw new Exception(e.Message);
            }
        }

        public BasicUsersDTO GetRentedUser(int id) {
            var bookObj = _bookContext.Single(book => book.Id == id);
            return _context.Users.Select(user => new BasicUsersDTO {
                Id = user.Id,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Avatar = user.Avatar
            }).Single(user => user.Id == bookObj.UsersRentId);
        }
        
        public BasicUsersDTO GetFundedUser(int id) {
            var bookObj = _bookContext.Single(book => book.Id == id);
            return _context.Users.Select(user => new BasicUsersDTO {
                Id = user.Id,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Avatar = user.Avatar
            }).Single(user => user.Id == bookObj.UsersFundId);
        }

        public int PostBooks(Books book) {
            try {
                
                _bookContext.Add(book);
                return _context.SaveChanges();
            }
            catch (DbUpdateException dbe) {
                if (dbe.InnerException is MySqlException mysqlEx)
                    switch (mysqlEx.Number) {
                        case 1062:
                            throw new DuplicationEntryException();
                        default:
                            throw new Exception();
                    }
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
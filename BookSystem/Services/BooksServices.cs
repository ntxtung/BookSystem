using System;
using System.Collections;
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

        public Object GetBookById(int id) {
            try {
                return _bookContext.Select(book => new {
                    book.Id,
                    book.Image,
                    book.Title
                }).Single(book => book.Id == id);

            }
            catch (InvalidOperationException e) {
                throw new Exception(e.Message);
            }
        }

        public IList GetAllBooks() {
            return _bookContext.Select(book => new {
                book.Id,
                book.Image,
                book.Title
            }).ToList();
        }

        public Object GetRentedUser(int id) {
            var bookObj = _bookContext.Single(book => book.Id == id);
            return _context.Users.Select(user => new {
                user.Id,
                user.Username,
                user.Firstname,
                user.Lastname,
                user.Email,
                user.Token,
                user.Avatar
            }).Where(user => user.Id == bookObj.UsersRentId);
        }

        public int RegisterNewBook(Books book) {
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

        public int UpdateBook(int id, Books newBook) {
            throw new NotImplementedException();
        }

        public int DeleteBook(int id) {
            _bookContext.Remove(_bookContext.Single(book => book.Id == id));
            return _context.SaveChanges();
        }
    }
}
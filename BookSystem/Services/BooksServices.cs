using System;
using System.Collections.Generic;
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

        public Books GetBookById(int id) {
            return _bookContext.Find(id);
        }

        public List<Books> GetAllBooks() {
            return _bookContext.ToList();
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
            throw new NotImplementedException();
        }
    }
}
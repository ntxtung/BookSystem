using System;
using System.Collections;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IBooksServices {
        Object GetBookById(int id);
        IList GetAllBooks();
        Object GetRentedUser(int id);
        int RegisterNewBook(Books book);
        int UpdateBook(int id, Books newBook);
        int DeleteBook(int id);
    }
}
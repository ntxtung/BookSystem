using System;
using System.Collections;
using System.Linq;
using BookSystem.Entities;

namespace BookSystem.Services {
    public interface IBooksServices {
        FullBooksDTO GetBookById(int id);
        IQueryable GetBooks();
        BasicUsersDTO GetRentedUser(int id);
        BasicUsersDTO GetFundedUser(int id);
        int PostBooks(Books book);
        int PutBooks(int id, Books newBook);
        int DeleteBooks(int id);
    }
}
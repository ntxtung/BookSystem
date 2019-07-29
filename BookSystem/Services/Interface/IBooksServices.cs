using System.Linq;
using BookSystem.Entities;
using BookSystem.Dtos;

namespace BookSystem.Services {
    public interface IBooksServices {
        FullBooksDto GetBookById(int id);
        IQueryable GetBooks(int page=1, int pageSize=5);
        BasicUsersDto GetRentedUser(int id);
        BasicUsersDto GetFundedUser(int id);
        int PostBooks(Books book);
        int PutBooks(int id, Books newBook);
        int DeleteBooks(int id);
    }
}
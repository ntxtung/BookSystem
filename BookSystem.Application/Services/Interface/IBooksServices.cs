using System.Linq;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;

namespace BookSystem.Application.Services.Interface {
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
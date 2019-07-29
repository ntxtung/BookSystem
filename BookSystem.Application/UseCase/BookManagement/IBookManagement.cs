using System.Linq;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;

namespace BookSystem.Application.UseCase.BookManagement {
    public interface IBookManagement {
        FullBooksDto GetBookById(int id);
        IQueryable GetBooks(int page=1, int pageSize=5);
        int PostBooks(Books book);
        int PutBooks(int id, Books newBook);
        int DeleteBooks(int id);
        BasicUsersDto GetRentedUser(int id);
        BasicUsersDto GetFundedUser(int id);
    }
}
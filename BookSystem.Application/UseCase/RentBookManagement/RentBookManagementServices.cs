using System.Linq;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;

namespace BookSystem.Application.UseCase.RentBookManagement {
    public class RentBookManagementServices : IRentBookManagementServices {
        private readonly BookSystemContext _context;

        public RentBookManagementServices() {
            _context = new BookSystemContext();
        }
        public IQueryable GetRentedBookOfUser(int id, int page = 1, int pageSize = 5) {
            return _context.Books
                .Where(book => book.UsersRentId == id)
                .Select(book => new FullBooksDto(book))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
        
        public int DoReturn(int userId, int bookId) {
            throw new System.NotImplementedException();
        }
    }
}
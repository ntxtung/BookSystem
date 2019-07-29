using System.Linq;
using BookSystem.Domain.Entities;
using BookSystem.WebApi.Dtos;

namespace BookSystem.Application.UseCase.FundBook {
    public class FundBookServices : IFundBookServices {
        private readonly BookSystemContext _context;

        public FundBookServices() {
            _context = new BookSystemContext();
        }

        public IQueryable GetFundedBookOfUser(int id, int page = 1, int pageSize = 5) {
            return _context.Books
                .Where(book => book.UsersFundId == id)
                .Select(book => new FullBooksDto(book))
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
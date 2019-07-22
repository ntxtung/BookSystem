using System.Linq;
using BookSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Services {
    public class DoResearchServices : IDoResearchServices {
        private readonly BookSystemContext _context;
        private readonly DbSet<Users> _userContext;
        
        public DoResearchServices() {
            _context = new BookSystemContext();
            _userContext = _context.Users;
        }

        public Users GetIncludeUserById(int id) {
            throw new System.NotImplementedException();
        }

        public IQueryable GetIncludeUsers() {
            return _userContext
                .Include(user => user.BooksUsersFund);
        }
    }
}
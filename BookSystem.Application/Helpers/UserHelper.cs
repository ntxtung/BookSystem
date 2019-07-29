using BookSystem.Domain.Entities;

namespace BookSystem.Application.Helpers {
    public class UserHelper {
        private readonly BookSystemContext _context;
        public UserHelper() {
            _context =  new BookSystemContext();
        }

        public Users FindUserById(int id) {
            return _context.Users.Find(id);
        }
    }
}
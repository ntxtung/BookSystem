using System.Collections;
using System.Linq;

namespace BookSystem.Services {
    public interface IRequestBookServices {
        int DoRequest(int userId, int bookId);
        int DoApprove(int userId, int bookId);
        int DoNotApprove(int userId, int bookId);
        IQueryable GetAllBooksUserDidRequest(int userId);
        IQueryable GetAllUsersWhoRequestBook(int bookId);
    }
}
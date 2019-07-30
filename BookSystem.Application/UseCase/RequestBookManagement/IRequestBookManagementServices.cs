using System.Linq;

namespace BookSystem.Application.UseCase.RequestBookManagement {
    public interface IRequestBookManagementServices {
        int DoRequest(int userId, int bookId);
        int DoApprove(int userId, int bookId);
        int DoNotApprove(int userId, int bookId);
        IQueryable GetAllBooksUserDidRequest(int userId, int page=1, int pageSize=5);
        IQueryable GetAllUsersWhoRequestBook(int bookId, int page=1, int pageSize=5);
    }
}
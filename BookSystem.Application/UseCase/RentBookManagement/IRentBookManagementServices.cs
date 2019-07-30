using System.Linq;

namespace BookSystem.Application.UseCase.RentBookManagement {
    public interface IRentBookManagementServices {
        IQueryable GetRentedBookOfUser(int id, int page=1, int pageSize=5);
        int DoReturn(int userId, int bookId);
    }
}
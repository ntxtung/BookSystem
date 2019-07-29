using System.Linq;

namespace BookSystem.Application.UseCase.RentBookManagement {
    public interface IRentBookManagementServices {
        IQueryable GetRentedBookOfUser(int id, int page=1, int pageSize=5);
    }
}
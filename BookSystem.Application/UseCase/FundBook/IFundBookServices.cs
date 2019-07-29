using System.Linq;

namespace BookSystem.Application.UseCase.FundBook {
    public interface IFundBookServices {
        IQueryable GetFundedBookOfUser(int id, int page=1, int pageSize=5);
    }
}
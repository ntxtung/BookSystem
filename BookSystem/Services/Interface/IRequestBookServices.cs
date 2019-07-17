using System.Collections;

namespace BookSystem.Services {
    public interface IRequestBookServices {
        int DoRequest(int userId, int bookId);
        int DoApprove(int userId, int bookId);
        IList GetAllRequester(int bookId);
    }
}
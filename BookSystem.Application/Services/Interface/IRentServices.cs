namespace BookSystem.Application.Services.Interface {
    public interface IRentServices {
        int DoReturn(int userId, int bookId);
        
    }
}
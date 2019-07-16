namespace BookSystem.Services {
    public interface IRentServices {
        int DoReturn(int userId, int bookId);
        
    }
}
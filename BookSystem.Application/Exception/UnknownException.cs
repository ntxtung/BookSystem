namespace BookSystem.Application.Exception {
    public class UnknownException : System.Exception {
        public UnknownException() {
        }

        public UnknownException(string message) : base(message) {
        }
    }
}
namespace BookSystem.WebApi.Helpers.Exception {
    public class InvalidEntry : ApiException {
        public InvalidEntry(string message, ApiExceptionCodeEnum exceptionCodeCode = ApiExceptionCodeEnum.Validation) : base(message, exceptionCodeCode) {
        }

        public InvalidEntry(System.Exception ex, ApiExceptionCodeEnum exceptionCodeCode = ApiExceptionCodeEnum.Validation) : base(ex, exceptionCodeCode) {
        }
    }
}
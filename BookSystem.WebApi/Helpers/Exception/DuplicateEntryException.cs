namespace BookSystem.WebApi.Helpers.Exception {
    public class DuplicateEntryException : ApiException {
        public DuplicateEntryException(string message = "Duplicate Entry", ApiExceptionCodeEnum exceptionCode = ApiExceptionCodeEnum.Duplicate) : base(message, exceptionCode) {
        }

        public DuplicateEntryException(System.Exception ex, ApiExceptionCodeEnum exceptionCode = ApiExceptionCodeEnum.Duplicate) : base(ex, exceptionCode) {
        }
    }
}
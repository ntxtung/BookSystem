namespace BookSystem.WebApi.Helpers.Exception {
    public class ApiException : System.Exception {
        public ApiExceptionCodeEnum ExceptionCodeCode { get; set; }

        public ApiException(string message = "Unknown Exception", ApiExceptionCodeEnum exceptionCodeCode = ApiExceptionCodeEnum.Unknown) : base(message) {
            ExceptionCodeCode = exceptionCodeCode;
        }

        public ApiException(System.Exception ex, ApiExceptionCodeEnum exceptionCodeCode = ApiExceptionCodeEnum.Unknown) : base(ex.Message) {
            ExceptionCodeCode = exceptionCodeCode;
        }
    }
}
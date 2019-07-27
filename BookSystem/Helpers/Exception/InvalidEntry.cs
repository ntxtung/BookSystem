using System;

namespace BookSystem.Helpers.ExceptionHelper {
    public class InvalidEntry : ApiException {
        public InvalidEntry(string message, ApiExceptionCodeEnum exceptionCodeCode = ApiExceptionCodeEnum.Validation) : base(message, exceptionCodeCode) {
        }

        public InvalidEntry(Exception ex, ApiExceptionCodeEnum exceptionCodeCode = ApiExceptionCodeEnum.Validation) : base(ex, exceptionCodeCode) {
        }
    }
}
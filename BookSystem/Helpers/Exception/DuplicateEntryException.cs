using System;

namespace BookSystem.Helpers.ExceptionHelper {
    public class DuplicateEntryException : ApiException {
        public DuplicateEntryException(string message = "Duplicate Entry", ApiExceptionCodeEnum exceptionCode = ApiExceptionCodeEnum.Duplicate) : base(message, exceptionCode) {
        }

        public DuplicateEntryException(Exception ex, ApiExceptionCodeEnum exceptionCode = ApiExceptionCodeEnum.Duplicate) : base(ex, exceptionCode) {
        }
    }
}
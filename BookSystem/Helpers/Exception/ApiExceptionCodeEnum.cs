using System.ComponentModel;

namespace BookSystem.Helpers.ExceptionHelper {
    public enum ApiExceptionCodeEnum{
        [Description("Duplicate Entry.")]  
        Duplicate = 2001,
        [Description("Invalid entry input.")]  
        Validation = 2002,  
        [Description("Unknown Exception.")]  
        Unknown = 9000
    }
}
using System;
using System.Runtime.Serialization;
using BookSystem.Helpers.ExceptionHelper;

namespace BookSystem.Helpers.ResponseHelper {
    [DataContract]
    public class ApiResponse {
        [DataMember] public string Version { get; set; }

        [DataMember] public int StatusCode { get; set; }

        [DataMember] public string Message { get; set; } 

        [DataMember(EmitDefaultValue = false)] public Object Data { get; set; }
        
        [DataMember(EmitDefaultValue = false)] public ApiException Exception { get; set; }

        public ApiResponse(int statusCode, string message = "", ApiException exception = null, Object data = null, string apiVersion = "1.0.0.0") {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Exception = exception;
            Version = apiVersion;
        }
    }
}
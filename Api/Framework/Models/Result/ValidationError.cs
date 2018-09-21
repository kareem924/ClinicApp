using System;

namespace Framework.Models.Result
{
    public class ValidationError
    {
        public string Message { get; set; }

        public string MessageType { get; set; }

        public Exception exception { get; set; }
       
      
        public ValidationError(string message)
        {
            Message = message;
        }

        public ValidationError(string message, string messageType)
        {
            Message = message;
            MessageType = messageType;
        }
        public ValidationError( Exception ex)
        {
            Message = ex.Message;
            MessageType = "500";
            exception = ex;
        }
    }
}
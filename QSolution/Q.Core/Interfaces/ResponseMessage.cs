using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Core.Interfaces
{
    public abstract class BaseResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        protected BaseResponse(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}

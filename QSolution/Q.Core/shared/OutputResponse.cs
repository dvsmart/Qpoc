using Q.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Core.shared
{
    public class OutputResponse : BaseResponse
    {
        public List<string> Errors { get; private set; }
        public OutputResponse(bool success, List<string> errors, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}

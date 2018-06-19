using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.API.Models
{
    public class ResponseModel
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
}

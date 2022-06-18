using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankClient.DTO {
    [Serializable]
    public class Response {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<Dictionary<string, string>> Errors {get; set;}
    }
}
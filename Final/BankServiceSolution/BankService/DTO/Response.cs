using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.DTO {
    [DataContract, Serializable]
    public class Response {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public Dictionary<string, string> Errors {get; set;}
    }
}
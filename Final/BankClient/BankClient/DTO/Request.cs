using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankClient.DTO {
    [Serializable]
    public class Request<T> {

        public int Id { get; set; }
 
        public string Token { get; set; }

        public T Object { get; set; }
    }
}
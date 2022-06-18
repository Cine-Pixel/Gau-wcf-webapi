using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BankService.DTO {
    [DataContract, Serializable]
    public class Request<T> {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public T Object { get; set; }
    }
}
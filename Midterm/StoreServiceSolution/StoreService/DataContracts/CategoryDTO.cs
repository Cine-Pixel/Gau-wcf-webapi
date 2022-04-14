using System;
using System.Runtime.Serialization;

namespace StoreService.DataContracts {
    [DataContract, Serializable]
    public class CategoryDTO {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }
}
using System;
using System.Runtime.Serialization;

namespace BankService.DTO
{
    [DataContract, Serializable]
    public class ApplicationDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? TypeId { get; set; }

        [DataMember]
        public int? ClientId { get; set; }

        [DataMember]
        public int? BranchId { get; set; }

        [DataMember]
        public bool? Approved { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }

        [DataMember]
        public BranchDTO Branch { get; set; }

        [DataMember]
        public ClientDTO Client { get; set; }

        [DataMember]
        public TypeDTO Type { get; set; }
    }
}

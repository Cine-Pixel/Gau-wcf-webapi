using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankService.DTO
{
    [DataContract, Serializable]
    public class GuarantorDTO
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Relationship { get; set; }

        [DataMember]
        public List<ClientDTO> Clients { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankService.DTO
{
    [DataContract, Serializable]
    public class BranchDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int? EmployeeId { get; set; }

        [DataMember]
        public List<ApplicationDTO> Applications { get; set; }

        [DataMember]
        public EmployeeDTO Employee { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankService.DTO
{
    [DataContract, Serializable]
    public class EmployeeDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int? BranchId { get; set; }

        [DataMember]
        public int? PositionId { get; set; }

        [DataMember]
        public BranchDTO Branch { get; set; }

        [DataMember]
        public PositionDTO Position { get; set; }
    }
}

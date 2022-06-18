using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankService.DTO
{
    [DataContract, Serializable]
    public class PositionDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<EmployeeDTO> Employees { get; set; }
    }
}

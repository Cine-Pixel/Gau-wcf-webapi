using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class BranchDTO
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? EmployeeId { get; set; }

        public List<ApplicationDTO> Applications { get; set; }

        public EmployeeDTO Employee { get; set; }
    }
}

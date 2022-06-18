using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? BranchId { get; set; }

        public int? PositionId { get; set; }

        public BranchDTO Branch { get; set; }

        public PositionDTO Position { get; set; }
    }
}

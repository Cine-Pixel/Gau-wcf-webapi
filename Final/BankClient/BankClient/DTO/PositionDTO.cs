using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class PositionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}

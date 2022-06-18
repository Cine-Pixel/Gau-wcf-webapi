using System;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class ApplicationDTO
    {
        public int Id { get; set; }

        public int? TypeId { get; set; }

        public int? ClientId { get; set; }

        public int? BranchId { get; set; }

        public bool? Approved { get; set; }

        public decimal? Amount { get; set; }

        public BranchDTO Branch { get; set; }

        public ClientDTO Client { get; set; }

        public TypeDTO Type { get; set; }
    }
}

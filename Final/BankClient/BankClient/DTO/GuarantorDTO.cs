using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class GuarantorDTO
    {
        public int? Id { get; set; }

        public string Relationship { get; set; }

        public List<ClientDTO> Clients { get; set; }
    }
}

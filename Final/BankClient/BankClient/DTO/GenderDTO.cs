using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class GenderDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ClientDTO> Clients { get; set; }
    }
}

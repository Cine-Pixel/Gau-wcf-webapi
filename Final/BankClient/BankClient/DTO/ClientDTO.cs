using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankClient.DTO
{
    [Serializable]
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? GenderId { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? GuarantorId { get; set; }

        public List<ApplicationDTO> Applications { get; set; }

        public CityDTO City { get; set; }

        public CountryDTO Country { get; set; }

        public GenderDTO Gender { get; set; }

        public GuarantorDTO Guarantor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BankService.DTO
{
    [DataContract, Serializable]
    public class ClientDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int? GenderId { get; set; }

        [DataMember]
        public string PersonalNumber { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public int? CountryId { get; set; }

        [DataMember]
        public int? CityId { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int? GuarantorId { get; set; }

        [DataMember]
        public List<ApplicationDTO> Applications { get; set; }

        [DataMember]
        public CityDTO City { get; set; }

        [DataMember]
        public CountryDTO Country { get; set; }

        [DataMember]
        public GenderDTO Gender { get; set; }

        [DataMember]
        public GuarantorDTO Guarantor { get; set; }
    }
}

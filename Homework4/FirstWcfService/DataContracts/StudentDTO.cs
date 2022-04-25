using System;
using System.Runtime.Serialization;

namespace FirstWcfService.DataContracts
{
    [DataContract]
    public class StudentDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public float GPA { get; set; }

        [DataMember]
        public DateTime BithDate { get; set; }
    }
}
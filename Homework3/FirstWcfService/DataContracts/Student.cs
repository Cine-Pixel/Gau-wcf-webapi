using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace FirstWcfService.DataContracts
{
    [DataContract]
    [Serializable]
    [XmlRoot]
    public class StudentDTO
    {
        //[DataMember]
        public int Id { get; set; }

        [DataMember]
        [XmlElement]
        public string FullName { get; set; }

        [DataMember]
        [XmlElement]
        public string FirstName { get; set; }

        [DataMember]
        [XmlElement]
        public string LastName { get; set; }

        [DataMember]
        [XmlElement]
        public float GPA { get; set; }

        [DataMember]
        [XmlElement]
        public DateTime BithDate { get; set; }
    }
}
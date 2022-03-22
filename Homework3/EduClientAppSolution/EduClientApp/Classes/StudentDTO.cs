using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EduClientApp.Classes
{

    [Serializable]
    //[XmlRoot(Namespace = "ArrayOfStudentDTO")]
    [XmlRoot(ElementName ="StudentDTO")]
    public class StudentDTO
    {      
        public int Id { get; set; }      
        [XmlElement]
        public string FullName { get; set; }
     
        [XmlElement]
        public string FirstName { get; set; }
      
        [XmlElement]
        public string LastName { get; set; }
     
        [XmlElement]
        public float GPA { get; set; }
       
        [XmlElement]
        public DateTime BithDate { get; set; }
    }
}

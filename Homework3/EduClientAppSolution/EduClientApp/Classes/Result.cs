using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EduClientApp.Classes
{
    [Serializable]
    [XmlRoot()]
    public class Result
    {
        [XmlElement]
        public bool IsSuccess { get; set; }
        [XmlElement]
        public string ErrorMessage { get; set; }
    }
}

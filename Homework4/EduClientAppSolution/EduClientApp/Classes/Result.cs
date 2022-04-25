using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EduClientApp.Classes
{
    [Serializable]
    public class Result
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}

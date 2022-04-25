using System;

namespace EduClientApp.Classes
{

    [Serializable]
    public class StudentDTO
    {      
        public int Id { get; set; }      

        public string FirstName { get; set; }
      
        public string LastName { get; set; }
     
        public float GPA { get; set; }
       
        public DateTime BithDate { get; set; }
    }
}

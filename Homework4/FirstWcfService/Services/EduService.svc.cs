﻿using System.Collections.Generic;
using FirstWcfService.DataContracts;
using FirstWcfService.BL;

namespace FirstWcfService
{
    public class EduService : IEduService
    {   
        public List<StudentDTO> GetAllStudents() => StudentManagement.GetAllStudents();
        public StudentDTO GetStudentById(string id) => StudentManagement.GetStudentById(id);
        public Result AddNewStudent(StudentDTO student) => StudentManagement.AddNewStudent(student); 
        public Result UpdateStudent(StudentDTO student) => StudentManagement.UpdateStudent(student);
        public Result DeleteStudent(string id) => StudentManagement.DeleteStudent(id);
    }
}

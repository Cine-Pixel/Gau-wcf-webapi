using FirstWcfService.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FirstWcfService
{   
    [ServiceContract]
    public interface IEduService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetAllStudents", ResponseFormat = WebMessageFormat.Json)]
        List<StudentDTO> GetAllStudents();

        [OperationContract]
        [WebGet(UriTemplate = "/GetStudentById/{id}", ResponseFormat = WebMessageFormat.Json)]
        StudentDTO GetStudentById(string id);

        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate = "/AddNewStudent", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result AddNewStudent(StudentDTO student);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/UpdateStudent", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result UpdateStudent(StudentDTO student);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteStudent/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Result DeleteStudent(string id);
    }
}

using FirstWcfService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FirstWcfService
{   
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IEduService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetAllStudents", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<StudentDTO> GetAllStudents();

        [OperationContract]
        [WebGet(UriTemplate = "/GetStudentById/{id}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        StudentDTO GetStudentById(string id);

        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate = "/AddNewStudent", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        Result AddNewStudent(StudentDTO student);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/UpdateStudent", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        Result UpdateStudent(StudentDTO student);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteStudent/{id}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        Result DeleteStudent(string id);
    }
}

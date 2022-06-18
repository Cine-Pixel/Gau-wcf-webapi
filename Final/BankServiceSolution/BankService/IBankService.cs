using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BankService.DTO;

namespace BankService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBankService {
        // Clients
        [OperationContract]
        [WebGet(UriTemplate = "/GetClients", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ClientDTO> GetClients();

        [OperationContract]
        [WebGet(
            UriTemplate = "/FilterClients?name={name}&gender={gender}&city={city}", 
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Bare
        )]
        List<ClientDTO> FilterClients(string name, string gender, string city);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddClient", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response AddClient(Request<ClientDTO> request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateClient", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response UpdateClient (Request<ClientDTO> request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/DeleteClient", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response DeleteClient(string id);

        // Application
        [OperationContract]
        [WebGet(UriTemplate = "/GetApplications?id={id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ApplicationDTO> GetApplications(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/CreateApplication", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response CreateApplication(Request<ApplicationDTO> request);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ApproveApplication", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Response ApproveApplication(Request<ApplicationDTO> request);

        // Constants
        [OperationContract]
        [WebGet(UriTemplate = "/GetGenders", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<GenderDTO> GetGenders();

        [OperationContract]
        [WebGet(UriTemplate = "/GetTypes", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TypeDTO> GetTypes();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCountries", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CountryDTO> GetCountries();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCities", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CityDTO> GetCities();

        [OperationContract]
        [WebGet(UriTemplate = "/GetGuarantors", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<GuarantorDTO> GetGuarantors();

        [OperationContract]
        [WebGet(UriTemplate = "/GetPositions", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<PositionDTO> GetPositions();
    }
}

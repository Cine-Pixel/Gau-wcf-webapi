using System;
using System.Collections.Generic;
using BankService.BL;
using BankService.DTO;

namespace BankService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BankService : IBankService {
        public List<ClientDTO> GetClients() => ClientManagement.GetClients();

        public List<ClientDTO> FilterClients(string name, string gender, string city) 
            => ClientManagement.FilterClients(name, gender, city);

        public Response UpdateClient(Request<ClientDTO> request) => ClientManagement.UpdateClient(request);

        public Response DeleteClient(string id) => ClientManagement.DeleteClient(id);

        public Response AddClient(Request<ClientDTO> request) => ClientManagement.AddClient(request);

        public List<ApplicationDTO> GetApplications(string id) => ApplicationManagement.GetApplications(id);

        public Response CreateApplication(Request<ApplicationDTO> request) => ApplicationManagement.CreateApplication(request);

        public Response ApproveApplication(Request<ApplicationDTO> request) => ApplicationManagement.ApproveApplication(request);

        public List<GenderDTO> GetGenders() => ConstantManagement.GetGenders();

        public List<TypeDTO> GetTypes() => ConstantManagement.GetTypes();

        public List<CountryDTO> GetCountries() => ConstantManagement.GetCountries();

        public List<CityDTO> GetCities() => ConstantManagement.GetCities();

        public List<GuarantorDTO> GetGuarantors() => ConstantManagement.GetGuarantors();

        public List<PositionDTO> GetPositions() => ConstantManagement.GetPositions();
    }
}

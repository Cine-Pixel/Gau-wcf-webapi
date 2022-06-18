using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankService.DTO;
using BankService.EF;
using BankService.Util;

namespace BankService.BL {
    public static class ClientManagement {
        public static List<ClientDTO> GetClients() {
            try {
                using(BankModel db = new BankModel()) {
                    List<ClientDTO> clients = db.Clients.Select(c => new ClientDTO {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PersonalNumber = c.PersonalNumber,
                        BirthDate = c.BirthDate,
                        Phone = c.Phone,
                        Email = c.Email,
                        City = new CityDTO { Id = c.City.Id, Name = c.City.Name },
                        Country = new CountryDTO { Id = c.Country.Id, Name = c.Country.Name },
                        Gender = new GenderDTO { Id = c.Gender.Id, Name = c.Gender.Name },
                        Guarantor = new GuarantorDTO { Id = c.Guarantor.Id, Relationship = c.Guarantor.Relationship }
                    }).ToList();
                    return clients;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<ClientDTO> {};
            }
        }

        public static List<ClientDTO> FilterClients(string name, string gender, string city) {
            try {
                using(BankModel db = new BankModel()) {
                    List<ClientDTO> clients = db.Clients.Where(
                        c => (c.FirstName.Contains(name) || c.LastName.Contains(name)) && c.Gender.Name.Contains(gender) &&  c.City.Name.Contains(city)
                    ).Select(c => new ClientDTO {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PersonalNumber = c.PersonalNumber,
                        BirthDate = c.BirthDate,
                        Phone = c.Phone,
                        Email = c.Email,
                        City = new CityDTO { Id = c.City.Id, Name = c.City.Name },
                        Country = new CountryDTO { Id = c.Country.Id, Name = c.Country.Name },
                        Gender = new GenderDTO { Id = c.Gender.Id, Name = c.Gender.Name },
                        Guarantor = new GuarantorDTO { Id = c.Guarantor.Id, Relationship = c.Guarantor.Relationship }
                    }).ToList();
                    return clients;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<ClientDTO> {};
            }
        }

        public static Response AddClient(Request<ClientDTO> request) {
            if(request.Token.Equals("")) {
                return new Response { Success = false, Message = "Unauthorized Request" };
            }
            ClientDTO newClient = request.Object;

            Dictionary<string, string> errors = Validation.ValidateClient(newClient);
            if(errors["Success"].Equals("0")) {
                return new Response { Success = false, Message = "Invalid Client Data", Errors = errors };
            }

            try {
                using(BankModel db = new BankModel()) {
                    Client client = new Client {
                        FirstName = newClient.FirstName,
                        LastName = newClient.LastName,
                        GenderId = newClient.GenderId,
                        PersonalNumber = newClient.PersonalNumber,
                        BirthDate = newClient.BirthDate,
                        CountryId = newClient.CountryId,
                        CityId = newClient.CityId,
                        Phone = newClient.Phone,
                        Email = newClient.Email,
                        GuarantorId = newClient.GuarantorId
                    };
                    db.Clients.Add(client);
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Client Added Succesfully" };
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return new Response { Success = false, Message = "Action Cannot be performed"};
            }
        }

        public static Response UpdateClient(Request<ClientDTO> request) {
            if(request.Token.Equals("")) {
                return new Response { Success = false, Message = "Unauthorized Request" };
            }

            ClientDTO oldClient = request.Object;
            try {
                using(BankModel db = new BankModel()) {
                    Client client = db.Clients.Where(c => c.Id == oldClient.Id).First();

                    client.FirstName = oldClient.FirstName;
                        client.LastName = oldClient.LastName;
                        client.GenderId = oldClient.GenderId;
                        client.PersonalNumber = oldClient.PersonalNumber;
                        client.BirthDate = oldClient.BirthDate;
                        client.CountryId = oldClient.CountryId;
                        client.CityId = oldClient.CityId;
                        client.Phone = oldClient.Phone;
                        client.Email = oldClient.Email;
                    client.GuarantorId = oldClient.GuarantorId;
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Client updated Succesfully" };
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return new Response { Success = false, Message = "Action cannot be performed"};
            }
        }

        public static Response DeleteClient(string id) {
            try {
                using (BankModel db = new BankModel()) {
                    if (!int.TryParse(id, out int code))
                        throw new Exception("Id was not found!");

                    if (!db.Clients.Any(i => i.Id == code))
                        throw new Exception($"Cannot find student with Id {id}!");

                    Client client = db.Clients.Where(i => i.Id == code).First();
                    db.Clients.Remove(client);
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Succesfully deleted product" };
                }
            }
            catch (Exception ex) {
                //return new Response { Success = false, Message = "Cannot delete product" };
                return new Response { Success = false, Message = ex.Message };
            }
        }
    }
}
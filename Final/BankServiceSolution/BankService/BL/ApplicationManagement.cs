using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankService.DTO;
using BankService.EF;

namespace BankService.BL {
    public static class ApplicationManagement {
        public static List<ApplicationDTO> GetApplications(string director_id) {
            if (!int.TryParse(director_id, out int id))
                return new List<ApplicationDTO>{ };

            try {
                using(BankModel db = new BankModel()) {
                    List<ApplicationDTO> clients = db.Applications.Where(app => app.BranchId == id)
                        .Select(app => new ApplicationDTO {
                            Id = app.Id,
                            Type = new TypeDTO { Id = app.Type.Id, Name = app.Type.Name },
                            TypeId = app.Type.Id,
                            Amount = app.Amount,
                            Approved = app.Approved,
                            BranchId = app.Branch.Id,
                            Branch = new BranchDTO {
                                Id = app.Branch.Id,
                                Address = app.Branch.Address,
                                Email = app.Branch.Email,
                                Phone = app.Branch.Phone
                            },
                            Client = new ClientDTO {
                                Id = app.Client.Id,
                                FirstName = app.Client.FirstName,
                                LastName = app.Client.LastName,
                                PersonalNumber = app.Client.PersonalNumber,
                                BirthDate = app.Client.BirthDate,
                                Phone = app.Client.Phone,
                                Email = app.Client.Email,
                            },
                            ClientId = app.Client.Id
                        }).ToList();
                    return clients;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<ApplicationDTO> {};
            }
        }

        public static Response CreateApplication(Request<ApplicationDTO> request) {
            if(request.Token.Equals("")) {
                return new Response { Success = false, Message = "Unauthorized request" };
            }

            ApplicationDTO application = request.Object;

            try {
                using(BankModel db = new BankModel()) {
                    Application app = new Application {
                        Amount = application.Amount,
                        Approved = false,
                        BranchId = application.BranchId,
                        ClientId = application.ClientId,
                        TypeId = application.TypeId
                    };
                    db.Applications.Add(app);
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Application has been created" };
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return new Response { Success = false, Message = "Action Cannot be performed"};
            }
        }

        public static Response ApproveApplication(Request<ApplicationDTO> request) {
            if(request.Token.Equals("")) {
                return new Response { Success = false, Message = "Unauthorized request" };
            }

            ApplicationDTO application = request.Object;

            try {
                using(BankModel db = new BankModel()) {
                    Employee employee = db.Employees.Where(e => e.Id == request.Id).FirstOrDefault();
                    if(!employee.Position.Name.Equals("director")) {
                        return new Response { Success = false, Message = "Unauthorized request" };
                    }

                    Application app = db.Applications.Where(a => a.Id == application.Id).FirstOrDefault();
                    if (app != null) {
                        app.Approved = true;
                    }
                    else {
                        return new Response { Success = false, Message = "Application was not found" };
                    }
                    db.SaveChanges();

                    return new Response { Success = true, Message = "Application has been approved" };
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return new Response { Success = false, Message = "Action Cannot be performed"};
            }
        }
    }
}
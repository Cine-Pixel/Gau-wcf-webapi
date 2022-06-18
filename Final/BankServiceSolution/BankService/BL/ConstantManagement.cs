using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankService.DTO;
using BankService.EF;

namespace BankService.BL {
    public static class ConstantManagement {
        public static List<GenderDTO> GetGenders() {
            try {
                using(BankModel db = new BankModel()) {
                    List<GenderDTO> gender= db.Genders.Select(c => new GenderDTO {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                    return gender;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<GenderDTO> {};
            }
        }

        public static List<TypeDTO> GetTypes() {
            try {
                using(BankModel db = new BankModel()) {
                    List<TypeDTO> types = db.Types.Select(c => new TypeDTO{
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                    return types;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<TypeDTO> {};
            }
        }

        public static List<CountryDTO> GetCountries() {
            try {
                using(BankModel db = new BankModel()) {
                    List<CountryDTO> countries = db.Countries.Select(c => new CountryDTO{
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                    return countries;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<CountryDTO> {};
            }
        }

        public static List<CityDTO> GetCities() {
            try {
                using(BankModel db = new BankModel()) {
                    List<CityDTO> cities = db.Cities.Select(c => new CityDTO{
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                    return cities;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<CityDTO> {};
            }
        }

        public static List<GuarantorDTO> GetGuarantors() {
            try {
                using(BankModel db = new BankModel()) {
                    List<GuarantorDTO> guarantors = db.Guarantors.Select(c => new GuarantorDTO {
                        Id = c.Id,
                        Relationship = c.Relationship
                    }).ToList();
                    return guarantors;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<GuarantorDTO> {};
            }
        }

        public static List<PositionDTO> GetPositions() {
            try {
                using(BankModel db = new BankModel()) {
                    List<PositionDTO> positions = db.Positions.Select(c => new PositionDTO {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
                    return positions;
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
                // throw ex;
                return new List<PositionDTO> {};
            }
        }
    }
}
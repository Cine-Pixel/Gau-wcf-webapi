using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using BankService.DTO;

namespace BankService.Util {
    public static class Validation {
        public static Dictionary<string, string> ValidateClient(ClientDTO client) {
            Dictionary <string, string> errors = new Dictionary<string, string>();
            errors.Add("Success", "1");
            if(client.FirstName.Length < 2 || client.FirstName.Length > 50) {
                errors.Add("FirstName", "Firstname should be between 2 and 50 characters");
                errors["Success"] = "0";
            }
            if(client.LastName.Length < 2 || client.LastName.Length > 50) {
                errors.Add("LastName", "Lastname should be between 2 and 50 characters");
                errors["Success"] = "0";
            }
            if(!Regex.IsMatch(client.PersonalNumber, @"^\d{11}$")) {
                errors.Add("PeronalNumber", "Personal number must be 11 digits long");
                errors["Success"] = "0";
            }
            if(!Regex.IsMatch(client.Phone, @"^\d{4,50}$")) {
                errors.Add("Phone", "Phone must be between 4 and 50 digits");
                errors["Success"] = "0";
            }
            if(!Regex.IsMatch(client.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")) {
                errors.Add("Email", "Email is not valid");
                errors["Success"] = "0";
            }
            return errors;
        }
    }
}
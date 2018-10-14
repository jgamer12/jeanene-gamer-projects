using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Models
{
    public class PurchaseVehicleViewModel : IValidatableObject
    {

        public VehicleSearchResult Vehicle { get; set; }
        public Customers Customer { get; set; }
        public Sales Sale { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Financing { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Customer.CustomerFirstName))
                errors.Add(new ValidationResult("First Name is required"));

            if (string.IsNullOrEmpty(Customer.CustomerLastName))
                errors.Add(new ValidationResult("Last Name is required"));

            if (string.IsNullOrEmpty(Customer.CustomerEmail) && string.IsNullOrEmpty(Customer.CustomerPhone))
                errors.Add(new ValidationResult("Either Email or Phone is required"));

            if (string.IsNullOrEmpty(Customer.CustomerStreet1))
                errors.Add(new ValidationResult("The street address is required"));

            if (string.IsNullOrEmpty(Customer.CustomerCity))
                errors.Add(new ValidationResult("The city is required"));

            if (string.IsNullOrEmpty(Customer.CustomerZipCode))
                errors.Add(new ValidationResult("The zip code is required"));

            var pattern = @"^[0-9]{5}$";
            var match = Regex.Match(Customer.CustomerZipCode, pattern);
            if (!match.Success)
                errors.Add(new ValidationResult("The zip code must be 5 digits"));            

            if (Sale.SaleAmount <= 0)
                errors.Add(new ValidationResult("Please enter a positive number."));

            if (Sale.SaleAmount > Vehicle.VehicleMSRP)
                errors.Add(new ValidationResult("Vehicle purchase price must be less than the MSRP"));

            if (Sale.SaleAmount < (.95M * Vehicle.VehicleSalesPrice))
                errors.Add(new ValidationResult("Vehicle purchase price must be more than 95% of the vehicle sales price"));



            return errors;
        }
    }
}
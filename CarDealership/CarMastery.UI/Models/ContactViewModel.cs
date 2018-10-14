using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models
{
    public class ContactViewModel : IValidatableObject
    {

        public ContactUs ContactToAdd { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ContactToAdd.ContactUsFirstName))
                errors.Add(new ValidationResult("First Name is required"));
            if (string.IsNullOrEmpty(ContactToAdd.ContactUsLastName))
                errors.Add(new ValidationResult("Last Name is required"));
            if (string.IsNullOrEmpty(ContactToAdd.ContactUsEmail) && string.IsNullOrEmpty(ContactToAdd.ContactUsPhone))
                errors.Add(new ValidationResult("Either Email or Phone is required"));
            if (string.IsNullOrEmpty(ContactToAdd.ContactUsMessage))
                errors.Add(new ValidationResult("Message is required"));

            return errors;
        }
    }
}
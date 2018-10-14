using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models
{
    public class SpecialsViewModel : IValidatableObject
    {
        public IEnumerable<Specials> SpecialsList { get; set; }
        public Specials SpecialToAdd { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(SpecialToAdd.SpecialDescription))
                errors.Add(new ValidationResult("Description is required"));
            if (string.IsNullOrEmpty(SpecialToAdd.SpecialDescription))
                errors.Add(new ValidationResult("Title is required"));
            return errors;
        }
    }
}
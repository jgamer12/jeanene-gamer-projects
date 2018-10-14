using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMastery.UI.Models
{
    public class MakesViewModel : IValidatableObject
    {
        public IEnumerable<MakesQuery> MakesList { get; set; }
        public Makes MakeToAdd { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(MakeToAdd.MakeDescription))
                errors.Add(new ValidationResult("Make description is required"));
            return errors;
        }
    }
}
using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Models
{
    public class ModelsViewModel : IValidatableObject
    {
        public IEnumerable<MakeModels> ModelsList { get; set; }
        public CarMastery.Models.Tables.Models ModelToAdd { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ModelToAdd.ModelDescription))
                errors.Add(new ValidationResult("Model description is required"));
            return errors;
        }
    }
}

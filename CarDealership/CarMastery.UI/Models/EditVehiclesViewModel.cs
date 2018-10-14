using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.UI.Models
{
    public class EditVehiclesViewModel : IValidatableObject
    {

        public Vehicles VehicleToEdit { get; set; }
        public int SelectedMake { get; set; }
        public IEnumerable<MakesQuery> Makes { get; set; }
        public IEnumerable<SelectListItem> VehicleType { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Transmission { get; set; }
        public IEnumerable<SelectListItem> BodyColor { get; set; }
        public IEnumerable<SelectListItem> InteriorColor { get; set; }
        public HttpPostedFileBase ReplacePicture { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            var currentDate = DateTime.Today;
            currentDate = currentDate.AddYears(1);
            var nextYear = currentDate.Year;

            if (string.IsNullOrEmpty(VehicleToEdit.VehicleYear.ToString()))
                errors.Add(new ValidationResult("Vehicle Year is required."));

            if (VehicleToEdit.VehicleYear < 2001 || VehicleToEdit.VehicleYear > nextYear)
                errors.Add(new ValidationResult("Please enter a Vehicle Year between 2000 and next year."));

            if (string.IsNullOrEmpty(VehicleToEdit.VehicleMileage.ToString()))
                errors.Add(new ValidationResult("Vehicle Mileage is required."));

            if (VehicleToEdit.VehicleTypeId == 1 && VehicleToEdit.VehicleMileage > 1000)
                errors.Add(new ValidationResult("Vehicles with more than 1000 miles are considered used."));

            if (VehicleToEdit.VehicleTypeId == 2 && VehicleToEdit.VehicleMileage < 1000)
                errors.Add(new ValidationResult("Vehicles with less than 1000 miles are considered new."));

            if (string.IsNullOrEmpty(VehicleToEdit.VehicleVIN))
                errors.Add(new ValidationResult("The vehicle VIN number is required."));

            if (VehicleToEdit.VehicleVIN.Length != 17 || string.IsNullOrEmpty(VehicleToEdit.VehicleVIN))
                errors.Add(new ValidationResult("The vehicle VIN number must be 17 positions long."));

            if (string.IsNullOrEmpty(VehicleToEdit.VehicleMSRP.ToString()))
                errors.Add(new ValidationResult("Vehicle MSRP is required."));

            if (VehicleToEdit.VehicleMSRP <= 0)
                errors.Add(new ValidationResult("Please enter a positive number."));

            if (string.IsNullOrEmpty(VehicleToEdit.VehicleSalesPrice.ToString()))
                errors.Add(new ValidationResult("Vehicle Sales Price is required."));

            if (VehicleToEdit.VehicleSalesPrice <= 0)
                errors.Add(new ValidationResult("Please enter a positive number."));

            if (VehicleToEdit.VehicleSalesPrice > VehicleToEdit.VehicleMSRP)
                errors.Add(new ValidationResult("Vehicle sales price must be less than the MSRP."));

            if (string.IsNullOrEmpty(VehicleToEdit.VehicleDescription))
                errors.Add(new ValidationResult("Description is required."));

            if (ReplacePicture != null && ReplacePicture.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ReplacePicture.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }

            return errors;
        }
    }
}
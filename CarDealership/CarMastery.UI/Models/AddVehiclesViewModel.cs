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
    public class AddVehiclesViewModel : IValidatableObject
    {

        public Vehicles VehicleToAdd { get; set; }
        public IEnumerable<MakesQuery> Makes { get; set; }
        public IEnumerable<SelectListItem> VehicleType { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Transmission { get; set; }
        public IEnumerable<SelectListItem> BodyColor { get; set; }
        public IEnumerable<SelectListItem> InteriorColor { get; set; }
        public HttpPostedFileBase PictureUpload { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            var currentDate = DateTime.Today;
            currentDate = currentDate.AddYears(1);
            var nextYear = currentDate.Year;

            if (string.IsNullOrEmpty(VehicleToAdd.VehicleYear.ToString()))            
                errors.Add(new ValidationResult("Vehicle Year is required."));            

            if (VehicleToAdd.VehicleYear < 2001 || VehicleToAdd.VehicleYear > nextYear)
                errors.Add(new ValidationResult("Please enter a Vehicle Year between 2000 and next year."));

            if (string.IsNullOrEmpty(VehicleToAdd.VehicleMileage.ToString()))
                errors.Add(new ValidationResult("Vehicle Mileage is required."));

            if (VehicleToAdd.VehicleTypeId == 1 && VehicleToAdd.VehicleMileage > 1000)
                errors.Add(new ValidationResult("Vehicles with more than 1000 miles are considered used."));

            if (VehicleToAdd.VehicleTypeId == 2 && VehicleToAdd.VehicleMileage < 1000)
                errors.Add(new ValidationResult("Vehicles with less than 1000 miles are considered new."));

            if (string.IsNullOrEmpty(VehicleToAdd.VehicleVIN))            
                errors.Add(new ValidationResult("The vehicle VIN number is required."));

            if (VehicleToAdd.VehicleVIN.Length != 17 || string.IsNullOrEmpty(VehicleToAdd.VehicleVIN))
                errors.Add(new ValidationResult("The vehicle VIN number must be 17 positions long."));

            if (string.IsNullOrEmpty(VehicleToAdd.VehicleMSRP.ToString()))
                errors.Add(new ValidationResult("Vehicle MSRP is required."));

            if (VehicleToAdd.VehicleMSRP <= 0)
                errors.Add(new ValidationResult("Please enter a positive number."));

            if (string.IsNullOrEmpty(VehicleToAdd.VehicleSalesPrice.ToString()))
                errors.Add(new ValidationResult("Vehicle Sales Price is required."));

            if (VehicleToAdd.VehicleSalesPrice <= 0)
                errors.Add(new ValidationResult("Please enter a positive number."));

            if(VehicleToAdd.VehicleSalesPrice > VehicleToAdd.VehicleMSRP)
                errors.Add(new ValidationResult("Vehicle sales price must be less than the MSRP."));

            if (string.IsNullOrEmpty(VehicleToAdd.VehicleDescription))            
                errors.Add(new ValidationResult("Description is required."));            

            if (PictureUpload != null && PictureUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(PictureUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Vehicle Picture is required."));
            }

            return errors;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class VehicleSearchResult
    {
        public int VehicleId { get; set; }
        public int VehicleYear { get; set; }
        public string MakeDescription { get; set; }
        public string ModelDescription { get; set; }
        public string VehicleTypeDescription { get; set; }
        public string BodyStyleDescription { get; set; }
        public string InteriorColorDescription { get; set; }
        public string TransmissionDescription { get; set; }
        public int VehicleMileage { get; set; }
        public string BodyColorDescription { get; set; }
        public string VehicleVIN { get; set; }
        public decimal VehicleSalesPrice { get; set; }
        public decimal VehicleMSRP { get; set; }
        public string VehiclePicture { get; set; }
        public string VehicleDescription { get; set; }
        public bool? VehicleIsFeatured { get; set; }
        public string VehicleSalesPriceFormatted { get; set; }
        public string VehicleMSRPFormatted { get; set; }
        public string VehicleMileageFormatted { get; set; }
        public bool? VehicleIsSold { get; set; }
    }
}

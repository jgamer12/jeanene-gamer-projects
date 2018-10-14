using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Vehicles
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BodyStyleId { get; set; }
        public int BodyColorId { get; set; }
        public int InteriorColorId { get; set; }
        public int TransmissionId { get; set; }
        public int VehicleYear { get; set; }
        public int VehicleMileage { get; set; }
        public string VehicleVIN { get; set; }
        public decimal VehicleMSRP { get; set; }
        public decimal VehicleSalesPrice { get; set; }
        public string VehicleDescription { get; set; }
        public string VehiclePicture { get; set; }
        public bool? VehicleIsFeatured { get; set; }
    }
}

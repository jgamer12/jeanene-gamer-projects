using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class FeaturedVehicleShortItem
    {
        public int VehicleId { get; set; }
        public int VehicleYear { get; set; }
        public string MakeDescription { get; set; }
        public string ModelDescription { get; set; }
        public decimal VehicleSalesPrice { get; set; }
        public string VehiclePicture { get; set; }
    }
}

using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class VehicleTypesRepositorySampleData : IVehicleTypesRepository
    {
        public static List<VehicleTypes> _VehicleTypes = new List<VehicleTypes>
        {
            new VehicleTypes
                {VehicleTypeId=1, VehicleTypeDescription = "New"},
            new VehicleTypes
                {VehicleTypeId=2, VehicleTypeDescription = "Used"}
        };

        public List<VehicleTypes> GetAllVehicleTypes()
        {
            return _VehicleTypes;
        }
    }
}

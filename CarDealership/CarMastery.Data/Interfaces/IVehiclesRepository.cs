using CarMastery.Models;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IVehiclesRepository
    {
        Vehicles SelectVehicle(int vehicleId);
        void AddVehicle (Vehicles vehicle);
        void DeleteVehicle(int vehicleId);
        void UpdateVehicle(Vehicles vehicle);
        int GetNextVehicleId();

    }
}

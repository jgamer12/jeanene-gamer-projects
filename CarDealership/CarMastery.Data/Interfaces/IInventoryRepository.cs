using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IInventoryRepository
    {
        IEnumerable<VehicleSearchResult> SearchInventory (VehicleSearchParameters parameters);
        IEnumerable<InventoryReport> CreateNewInventoryReport();
        IEnumerable<InventoryReport> CreateUsedInventoryReport();
        VehicleSearchResult GetVehicleDetails(int vehicleId);
        IEnumerable<FeaturedVehicleShortItem> GetFeaturedVehicles();
        bool IsSold(int vehicleId);

    }
}

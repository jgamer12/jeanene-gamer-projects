using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.ADO
{
    public class InventoryRepositoryADO : IInventoryRepository
    {
        public IEnumerable<InventoryReport> CreateNewInventoryReport()
        {
            List<InventoryReport> newInventory = new List<InventoryReport>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport currentRow = new InventoryReport();
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.ModelDescription = dr["ModelDescription"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["StockValue"];
                        newInventory.Add(currentRow);
                    }
                }
            }
            return newInventory;
        }

        public IEnumerable<InventoryReport> CreateUsedInventoryReport()
        {
            List<InventoryReport> usedInventory = new List<InventoryReport>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport currentRow = new InventoryReport();
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.ModelDescription = dr["ModelDescription"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["StockValue"];
                        usedInventory.Add(currentRow);
                    }
                }
            }
            return usedInventory;
        }

        public IEnumerable<FeaturedVehicleShortItem> GetFeaturedVehicles()
        {
            List<FeaturedVehicleShortItem> featuredVehicles = new List<FeaturedVehicleShortItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetFeaturedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicleShortItem currentRow = new FeaturedVehicleShortItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.ModelDescription = dr["ModelDescription"].ToString();
                        currentRow.VehicleSalesPrice = (decimal)dr["VehicleSalesPrice"];
                        currentRow.VehiclePicture = dr["VehiclePicture"].ToString();

                        featuredVehicles.Add(currentRow);
                    }
                }
            }
            return featuredVehicles;
        }

        public VehicleSearchResult GetVehicleDetails(int vehicleId)
        {
            VehicleSearchResult vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicleDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleSearchResult();
                        vehicle.VehicleId = (int)vehicleId;
                        vehicle.VehicleYear = (int)dr["VehicleYear"];
                        vehicle.MakeDescription = dr["MakeDescription"].ToString();
                        vehicle.ModelDescription = dr["ModelDescription"].ToString();
                        vehicle.BodyStyleDescription = dr["BodyStyleDescription"].ToString();
                        vehicle.InteriorColorDescription = dr["InteriorColorDescription"].ToString();
                        vehicle.TransmissionDescription = dr["TransmissionDescription"].ToString();
                        vehicle.VehicleMileage = (int)dr["VehicleMileage"];
                        vehicle.BodyColorDescription = dr["BodyColorDescription"].ToString();
                        vehicle.VehicleVIN = dr["VehicleVIN"].ToString();
                        vehicle.VehicleSalesPrice = (decimal)dr["VehicleSalesPrice"];
                        vehicle.VehicleMSRP = (decimal)dr["VehicleMSRP"];
                        vehicle.VehiclePicture = dr["VehiclePicture"].ToString();
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();

                        vehicle.VehicleSalesPriceFormatted = vehicle.VehicleSalesPrice.ToString("c0");
                        vehicle.VehicleMSRPFormatted = vehicle.VehicleMSRP.ToString("c0");
                        if (vehicle.VehicleMileage < 1000)
                            vehicle.VehicleMileageFormatted = "New";
                        else
                            vehicle.VehicleMileageFormatted = Convert.ToDecimal(vehicle.VehicleMileage).ToString("#,##0");
                        vehicle.VehicleIsSold = IsSold(vehicle.VehicleId);
                    }
                }
            }
            return vehicle;
        }

        public bool IsSold(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("IsSold", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    return dr.Read();
                }
            }
        }

        public IEnumerable<VehicleSearchResult> SearchInventory(VehicleSearchParameters parameters)
        {
            List<VehicleSearchResult> vehicles = new List<VehicleSearchResult>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 Vehicles.VehicleId, VehicleYear, MakeDescription, ModelDescription, VehicleTypeDescription, ";
                query += "BodyStyleDescription, InteriorColorDescription, TransmissionDescription, VehicleMileage, BodyColorDescription, VehicleVIN, ";
                query += "VehicleSalesPrice, VehicleMSRP, VehiclePicture, VehicleDescription, VehicleIsFeatured ";
                query += "FROM Vehicles LEFT JOIN Sales ON Vehicles.VehicleId = Sales.VehicleId INNER JOIN BodyStyles ON Vehicles.BodyStyleId = BodyStyles.BodyStyleId ";
                query += "INNER JOIN InteriorColors ON Vehicles.InteriorColorId = InteriorColors.InteriorColorId ";
                query += "INNER JOIN Transmissions ON Vehicles.TransmissionId = Transmissions.TransmissionId ";
                query += "INNER JOIN VehicleTypes ON Vehicles.VehicleTypeId = VehicleTypes.VehicleTypeId ";
                query += "INNER JOIN BodyColors ON Vehicles.BodyColorId = BodyColors.BodyColorId  INNER JOIN Models ON Vehicles.ModelId = Models.ModelId ";
                query += "INNER JOIN Makes ON Makes.MakeId = Models.MakeId WHERE SaleId IS NULL AND 1 = 1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.NewUsed))
                {
                    query += $"AND VehicleTypeDescription = @NewUsed ";
                    cmd.Parameters.AddWithValue("@NewUsed", parameters.NewUsed);
                }
                if (parameters.MinPrice.HasValue)
                {
                    query += $"AND VehicleSalesPrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }
               if (parameters.MaxPrice.HasValue)
                {
                    query += $"AND VehicleSalesPrice <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }
                if (parameters.MinYear.HasValue)
                {
                    query += $"AND VehicleYear >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }
                if (parameters.MaxYear.HasValue)
                {
                    query += $"AND VehicleYear <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }
                

                if (!string.IsNullOrEmpty(parameters.MakeModelYear) && int.TryParse(parameters.MakeModelYear, out int year))
                {
                    query += $"AND VehicleYear = @Year ";
                    cmd.Parameters.AddWithValue("@Year", year);
                }
                else if (!string.IsNullOrEmpty(parameters.MakeModelYear))
                {
                    query += $"AND (MakeDescription LIKE @MakeModelYear OR ModelDescription LIKE @MakeModelYear) ";
                    cmd.Parameters.AddWithValue("@MakeModelYear", parameters.MakeModelYear+'%');
                }
                query += "ORDER BY VehicleMSRP DESC";

                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleSearchResult currentRow = new VehicleSearchResult();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.ModelDescription = dr["ModelDescription"].ToString();
                        currentRow.VehicleTypeDescription = dr["VehicleTypeDescription"].ToString();
                        currentRow.BodyStyleDescription = dr["BodyStyleDescription"].ToString();
                        currentRow.InteriorColorDescription = dr["InteriorColorDescription"].ToString();
                        currentRow.TransmissionDescription = dr["TransmissionDescription"].ToString();
                        currentRow.VehicleMileage = (int)dr["VehicleMileage"];
                        currentRow.BodyColorDescription = dr["BodyColorDescription"].ToString();
                        currentRow.VehicleVIN = dr["VehicleVIN"].ToString();
                        currentRow.VehicleSalesPrice = (decimal)dr["VehicleSalesPrice"];
                        currentRow.VehicleMSRP = (decimal)dr["VehicleMSRP"];
                        currentRow.VehiclePicture = dr["VehiclePicture"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleIsFeatured = (bool)dr["VehicleIsFeatured"];

                        currentRow.VehicleSalesPriceFormatted = currentRow.VehicleSalesPrice.ToString("c0");
                        currentRow.VehicleMSRPFormatted = currentRow.VehicleMSRP.ToString("c0");
                        if (currentRow.VehicleMileage < 1000)
                            currentRow.VehicleMileageFormatted = "New";
                        else
                            currentRow.VehicleMileageFormatted = Convert.ToDecimal(currentRow.VehicleMileage).ToString("#,##0");

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }
    }
}

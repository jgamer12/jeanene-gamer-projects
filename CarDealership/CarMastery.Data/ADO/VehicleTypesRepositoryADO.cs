using CarMastery.Data.Interfaces;
using CarMastery.Models;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.ADO
{
    public class VehicleTypesRepositoryADO : IVehicleTypesRepository
    {
        public List<VehicleTypes> GetAllVehicleTypes()
        {
            List<VehicleTypes> vehicleTypes = new List<VehicleTypes>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleTypes currentRow = new VehicleTypes();
                        currentRow.VehicleTypeId = (int)dr["VehicleTypeId"];
                        currentRow.VehicleTypeDescription = dr["VehicleTypeDescription"].ToString();

                        vehicleTypes.Add(currentRow);
                    }
                }
            }
            return vehicleTypes;
        }
    }
}

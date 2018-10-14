using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
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
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public void AddVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicle.VehicleTypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@BodyColorId", vehicle.BodyColorId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicle.TransmissionId);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@VehicleMileage", vehicle.VehicleMileage);
                cmd.Parameters.AddWithValue("@VehicleVIN", vehicle.VehicleVIN);
                cmd.Parameters.AddWithValue("@VehicleMSRP", vehicle.VehicleMSRP);
                cmd.Parameters.AddWithValue("@VehicleSalesPrice", vehicle.VehicleSalesPrice);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehiclePicture", vehicle.VehiclePicture);
                if (vehicle.VehicleIsFeatured == null)
                    cmd.Parameters.AddWithValue("@VehicleIsFeatured", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@VehicleIsFeatured", vehicle.VehicleIsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleId = (int)param.Value;
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public int GetNextVehicleId()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetNextVehicleId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                object result = cmd.ExecuteScalar();
                int nextId = (result == null ? (int)0 : Convert.ToInt32(result));
                return nextId;
            }
        }

        public Vehicles SelectVehicle(int vehicleId)
        {
            Vehicles vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicles();
                        vehicle.VehicleId = (int)dr["vehicleId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.VehicleTypeId = (int)dr["VehicleTypeId"];
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.BodyColorId = (int)dr["BodyColorId"];
                        vehicle.InteriorColorId = (int)dr["InteriorColorId"];
                        vehicle.TransmissionId = (int)dr["TransmissionId"];
                        vehicle.VehicleYear = (int)dr["VehicleYear"];
                        vehicle.VehicleMileage = (int)dr["VehicleMileage"];
                        vehicle.VehicleVIN = dr["VehicleVIN"].ToString();
                        vehicle.VehicleMSRP = (decimal)dr["VehicleMSRP"];
                        vehicle.VehicleSalesPrice = (decimal)dr["VehicleSalesPrice"];
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        vehicle.VehiclePicture = dr["VehiclePicture"].ToString();
                        if (dr["VehicleIsFeatured"] != DBNull.Value)
                            vehicle.VehicleIsFeatured = (bool?)dr["VehicleIsFeatured"];
                    }
                }
            }
            return vehicle;
        }

        public void UpdateVehicle(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@VehicleTypeId", vehicle.VehicleTypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@BodyColorId", vehicle.BodyColorId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@TransmissionId", vehicle.TransmissionId);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@VehicleMileage", vehicle.VehicleMileage);
                cmd.Parameters.AddWithValue("@VehicleVIN", vehicle.VehicleVIN);
                cmd.Parameters.AddWithValue("@VehicleMSRP", vehicle.VehicleMSRP);
                cmd.Parameters.AddWithValue("@VehicleSalesPrice", vehicle.VehicleSalesPrice);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehiclePicture", vehicle.VehiclePicture);
                if (vehicle.VehicleIsFeatured == null)
                    cmd.Parameters.AddWithValue("@VehicleIsFeatured", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@VehicleIsFeatured", vehicle.VehicleIsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}

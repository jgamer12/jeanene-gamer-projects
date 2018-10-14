using CarMastery.Data.Interfaces;
using CarMastery.Models;
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
    public class ModelsRepositoryADO : IModelsRepository
    {
        public void AddModel(Models.Tables.Models model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                cmd.Parameters.AddWithValue("@ModelDescription", model.ModelDescription);
                cmd.Parameters.AddWithValue("@ModelDateAdded", model.ModelDateAdded);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }

        public IEnumerable<MakeModels> GetAllModels()
        {
            List<MakeModels> models = new List<MakeModels>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeModels currentRow = new MakeModels();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.ModelDescription = dr["ModelDescription"].ToString();
                        currentRow.ModelDateAdded = (DateTime)dr["ModelDateAdded"];

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public IEnumerable<MakeModels> GetModelsForMake(int makeId)
        {
            List<MakeModels> models = new List<MakeModels>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsGetByMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeModels currentRow = new MakeModels();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.ModelDescription = dr["ModelDescription"].ToString();
                        currentRow.ModelDateAdded = (DateTime)dr["ModelDateAdded"];

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }
    }
}
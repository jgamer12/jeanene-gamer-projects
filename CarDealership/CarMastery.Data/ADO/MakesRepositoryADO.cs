using CarMastery.Data.Interfaces;
using CarMastery.Models;
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
    public class MakesRepositoryADO : IMakesRepository
    {
        public void AddMake(Makes make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", make.UserId);
                cmd.Parameters.AddWithValue("@MakeDescription", make.MakeDescription);
                cmd.Parameters.AddWithValue("@MakeDateAdded", make.MakeDateAdded);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (int)param.Value;
            }
        }

        public IEnumerable<MakesQuery> GetAllMakes()
        {
            List<MakesQuery> makes = new List<MakesQuery>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakesQuery currentRow = new MakesQuery();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.MakeDescription = dr["MakeDescription"].ToString();
                        currentRow.MakeDateAdded = (DateTime)dr["MakeDateAdded"];

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }

        public Makes GetMakeForModel(int modelId)
        {
            Makes make = new Makes();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetMakeForModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelId", modelId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        make.MakeId = (int)dr["MakeId"];
                        make.MakeDescription = dr["MakeDescription"].ToString();
                        make.UserId = dr["UserId"].ToString();
                        make.MakeDateAdded = (DateTime)dr["MakeDateAdded"];
                    }
                }
            }
            return make;
        }
    }
}

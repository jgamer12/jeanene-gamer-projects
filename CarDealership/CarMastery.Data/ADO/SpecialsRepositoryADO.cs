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
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public IEnumerable<Specials> GetAllSpecials()
        {
            List<Specials> specials = new List<Specials>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialId = (int)dr["SpecialId"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }

        public void AddSpecial(Specials special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddSpecial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialId = (int)param.Value;
            }
        }

        public void DeleteSpecial(int specialId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecialById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", specialId);
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Specials GetSpecialById(int SpecialId)
        {

            Specials special = new Specials();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetSpecial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", SpecialId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special.SpecialId = (int)SpecialId;
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.SpecialDescription = dr["SpecialDescription"].ToString();
                    }
                }
                return special;
            }
        }
    }
}

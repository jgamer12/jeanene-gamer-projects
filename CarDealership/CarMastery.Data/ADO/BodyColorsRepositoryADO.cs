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
    public class BodyColorsRepositoryADO : IBodyColorsRepository
    {
        public List<BodyColors> GetAllBodyColors()
        {
            List<BodyColors> bodyColors = new List<BodyColors>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyColors currentRow = new BodyColors();
                        currentRow.BodyColorId = (int)dr["BodyColorId"];
                        currentRow.BodyColorDescription = dr["BodyColorDescription"].ToString();

                        bodyColors.Add(currentRow);
                    }
                }
            }
            return bodyColors;
        }
    }
}

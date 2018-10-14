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
    public class BodyStylesRepositoryADO : IBodyStylesRepository
    {
        public List<BodyStyles> GetAllBodyStyles()
        {
            List<BodyStyles> bodyStyles = new List<BodyStyles>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStylesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyles currentRow = new BodyStyles();
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.BodyStyleDescription = dr["BodyStyleDescription"].ToString();

                        bodyStyles.Add(currentRow);
                    }
                }
            }
            return bodyStyles;
        }
    }
}

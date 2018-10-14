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
    public class InteriorColorsRepositoryADO : IInteriorColorsRepository
    {
        public List<InteriorColors> GetAllInteriorColors()
        {
            List<InteriorColors> interiorColors = new List<InteriorColors>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColors currentRow = new InteriorColors();
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.InteriorColorDescription = dr["InteriorColorDescription"].ToString();

                        interiorColors.Add(currentRow);
                    }
                }
            }
            return interiorColors;
        }
    }
}

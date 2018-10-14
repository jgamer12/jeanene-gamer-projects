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
    public class FinancingRepositoryADO : IFinancingRepository
    {
        public List<Financing> GetAllFinancing()
        {
            List<Financing> financing = new List<Financing>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FinancingSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Financing currentRow = new Financing();
                        currentRow.FinancingId = (int)dr["FinancingId"];
                        currentRow.FinancingDescription = dr["FinancingDescription"].ToString();

                        financing.Add(currentRow);
                    }
                }
            }
            return financing;
        }
    }
}

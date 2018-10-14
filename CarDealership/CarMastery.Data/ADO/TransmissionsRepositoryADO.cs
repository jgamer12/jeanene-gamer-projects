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
    public class TransmissionsRepositoryADO : ITransmissionsRepository
    {
        public List<Transmissions> GetAllTransmissions()
        {
            List<Transmissions> transmissions = new List<Transmissions>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmissions currentRow = new Transmissions();
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.TransmissionDescription = dr["TransmissionDescription"].ToString();

                        transmissions.Add(currentRow);
                    }
                }
            }
            return transmissions;
        }
    }
}

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
    public class SalesRepositoryADO : ISalesRepository
    {
        public void AddSale(Sales sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddSale", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SaleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CustomerId", sale.CustomerId);
                cmd.Parameters.AddWithValue("@VehicleId", sale.VehicleId);
                cmd.Parameters.AddWithValue("@FinancingId", sale.FinancingId);
                cmd.Parameters.AddWithValue("@UserId", sale.UserId);
                cmd.Parameters.AddWithValue("@SaleAmount", sale.SaleAmount);
                cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);

                cn.Open();

                cmd.ExecuteNonQuery();

                sale.SaleId = (int)param.Value;
            }
        }

        public IEnumerable<Sales> GetAllSales()
        {
            List<Sales> sales = new List<Sales>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sales currentRow = new Sales();
                        currentRow.SaleId = (int)dr["SaleId"];
                        currentRow.CustomerId = (int)dr["CustomerId"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.FinancingId = (int)dr["FinancingId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.SaleAmount = (decimal)dr["SaleAmount"];
                        currentRow.SaleDate = (DateTime)dr["SaleDate"];

                        sales.Add(currentRow);
                    }
                }
            }
            return sales;
        }

        public IEnumerable<SalesReport> GetSalesForReport(SalesReportSearchParameters parameters)
        {
            List<SalesReport> salesReport = new List<SalesReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT s.UserId, u.FirstName + ' ' + u.LastName AS UserName, COUNT(VehicleId) AS [TotalVehicles], SUM(SaleAmount) AS [TotalSales] ";
                query += "FROM Sales s INNER JOIN AspNetUsers u ON u.Id = s.UserId  WHERE 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.UserId))
                {
                    query += $"AND s.UserId = @UserId ";
                    cmd.Parameters.AddWithValue("@UserId", parameters.UserId);
                }

                DateTime ParsedFromDate;
                if (!string.IsNullOrEmpty(parameters.FromDate) && DateTime.TryParse(parameters.FromDate, out ParsedFromDate))
                {
                    query += $"AND s.SaleDate >= @FromDate ";
                    cmd.Parameters.AddWithValue("@FromDate", ParsedFromDate);
                }

                DateTime ParsedToDate;
                if (!string.IsNullOrEmpty(parameters.ToDate) && DateTime.TryParse(parameters.ToDate, out ParsedToDate))
                {
                    query += $"AND s.SaleDate <= @ToDate ";
                    cmd.Parameters.AddWithValue("@ToDate", ParsedToDate);
                }

                query += "GROUP BY s.UserId, u.FirstName, u.LastName ";
                query += "ORDER BY TotalSales DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport currentRow = new SalesReport();
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];

                        currentRow.TotalSalesFormatted = currentRow.TotalSales.ToString("c0");

                        salesReport.Add(currentRow);
                    }
                }
            }
            return salesReport;
        }
    }


}

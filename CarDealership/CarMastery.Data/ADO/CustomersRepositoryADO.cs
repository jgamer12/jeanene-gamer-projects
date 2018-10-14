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
    public class CustomersRepositoryADO : ICustomersRepository
    {
        public void AddCustomer(Customers customer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddCustomer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CustomerId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@StateId", customer.StateId);
                cmd.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
                cmd.Parameters.AddWithValue("@CustomerLastName", customer.CustomerLastName);
                if (string.IsNullOrEmpty(customer.CustomerEmail))
                    cmd.Parameters.AddWithValue("@CustomerEmail", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
                if (string.IsNullOrEmpty(customer.CustomerPhone))
                    cmd.Parameters.AddWithValue("@CustomerPhone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerStreet1", customer.CustomerStreet1);
                if (string.IsNullOrEmpty(customer.CustomerStreet2))
                    cmd.Parameters.AddWithValue("@CustomerStreet2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@CustomerStreet2", customer.CustomerStreet2);
                cmd.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
                cmd.Parameters.AddWithValue("@CustomerZipCode", customer.CustomerZipCode);

                cn.Open();

                cmd.ExecuteNonQuery();

                customer.CustomerId = (int)param.Value;
            }
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Customers currentRow = new Customers();
                        currentRow.CustomerId = (int)dr["CustomerId"];
                        currentRow.StateId = dr["StateId"].ToString();
                        currentRow.CustomerFirstName = dr["CustomerFirstName"].ToString();
                        currentRow.CustomerLastName = dr["CustomerLastName"].ToString();
                        currentRow.CustomerPhone = dr["CustomerPhone"].ToString();
                        currentRow.CustomerEmail = dr["CustomerEmail"].ToString();
                        currentRow.CustomerStreet1 = dr["CustomerStreet1"].ToString();
                        currentRow.CustomerStreet2 = dr["CustomerStreet2"].ToString();
                        currentRow.CustomerCity = dr["CustomerCity"].ToString();
                        currentRow.CustomerZipCode = dr["CustomerZipCode"].ToString();

                        customers.Add(currentRow);
                    }
                }
            }
            return customers;
        }
    }
}

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
    public class ContactUsRepositoryADO : IContactUsRepository
    {
        public void AddContact(ContactUs contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactUsId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ContactUsFirstName", contact.ContactUsFirstName);
                cmd.Parameters.AddWithValue("@ContactUsLastName", contact.ContactUsLastName);
                if (string.IsNullOrEmpty(contact.ContactUsEmail))
                    cmd.Parameters.AddWithValue("@ContactUsEmail", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ContactUsEmail", contact.ContactUsEmail);
                if (string.IsNullOrEmpty(contact.ContactUsPhone))
                    cmd.Parameters.AddWithValue("@ContactUsPhone", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ContactUsPhone", contact.ContactUsPhone);
                cmd.Parameters.AddWithValue("@ContactUsMessage", contact.ContactUsMessage);

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactUsId = (int)param.Value;
            }
        }

        public List<ContactUs> GetAllContactRequests()
        {
            List<ContactUs> contacts = new List<ContactUs>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactUsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ContactUs currentRow = new ContactUs();
                        currentRow.ContactUsId = (int)dr["ContactUsId"];
                        currentRow.ContactUsFirstName = dr["ContactUsFirstName"].ToString();
                        currentRow.ContactUsLastName = dr["ContactUsLastName"].ToString();
                        currentRow.ContactUsEmail = dr["ContactUsEmail"].ToString();
                        currentRow.ContactUsPhone = dr["ContactUsPhone"].ToString();
                        currentRow.ContactUsMessage = dr["ContactUsMessage"].ToString();

                        contacts.Add(currentRow);
                    }
                }
            }
            return contacts;
        }
    }
}

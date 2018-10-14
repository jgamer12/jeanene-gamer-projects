using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.ADO
{
    public class UsersRepositoryADO : IUsersRepository
    {
        public IEnumerable<Roles> GetAllRoles()
        {
            List<Roles> roles = new List<Roles>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectAllRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Roles currentRow = new Roles();
                        currentRow.Id = dr["Id"].ToString();
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Discriminator = dr["Discriminator"].ToString();

                        roles.Add(currentRow);
                    }
                }
            }
            return roles;
        }

        public IEnumerable<SalesUserIdAndName> GetAllSalesUsers()
        {
            List<SalesUserIdAndName> users = new List<SalesUserIdAndName>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesUserIdAndName", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesUserIdAndName currentRow = new SalesUserIdAndName();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.UserName = dr["UserName"].ToString();

                        users.Add(currentRow);
                    }
                }
            }
            return users;
        }

        public Roles GetRoleNameForId(string roleId)
        {

            Roles role = new Roles();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetRoleNameForId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RoleId", roleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        role.Id = dr["Id"].ToString();
                        role.Name = dr["Name"].ToString();
                        role.Discriminator = dr["Discriminator"].ToString();
                    }
                }
                return role;
            }
        }

        public UsersRole GetUserById(string userId)
        {

            UsersRole user = new UsersRole();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetUserById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", userId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        user.UserId = dr["UserId"].ToString();
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.Role = dr["Role"].ToString();
                        user.RoleId = dr["RoleId"].ToString();
                    }
                }
                return user;
            }
        }

        public IEnumerable<UsersRole> GetAllUsers()
        {
            List<UsersRole> users = new List<UsersRole>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UsersRole currentRow = new UsersRole();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Role = dr["Role"].ToString();
                        currentRow.RoleId = dr["RoleId"].ToString();

                        users.Add(currentRow);
                    }
                }
            }
            return users;
        }
    }
}

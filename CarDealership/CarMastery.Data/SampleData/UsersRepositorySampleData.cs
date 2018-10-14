using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class UsersRepositorySampleData : IUsersRepository
    {
        public static List<UsersRole> _Users = new List<UsersRole>
        {
            new UsersRole
            {UserId = "00000000-0000-0000-0000-000000000000", FirstName = "Test", LastName = "Adminuser", Email = "testadminuser@test.com", Role = "Admin", RoleId = "27ca2a56-e86a-476d-91bc-033d438d8ce4" },
            new UsersRole
            {UserId = "f0582e80-c784-4002-933a-034f6afe54fb", FirstName = "Test", LastName = "Adminseed", Email = "adminseed@test.com", Role = "Admin", RoleId = "27ca2a56-e86a-476d-91bc-033d438d8ce4" },
            new UsersRole
            {UserId = "11111111-1111-1111-1111-111111111111", FirstName = "Test", LastName = "Salesuser1", Email = "testsalesuser1@test.com", Role = "Sales", RoleId = "cbe2009c-472f-4739-830f-d87368ec6ca4" },
            new UsersRole
            {UserId = "22222222-2222-2222-2222-222222222222", FirstName = "Test", LastName = "Salesuser2", Email = "testsalesuser2@test.com", Role = "Sales", RoleId = "cbe2009c-472f-4739-830f-d87368ec6ca4" },
            new UsersRole
            {UserId = "33333333-3333-3333-3333-333333333333", FirstName = "Test", LastName = "Salesuser3", Email = "testsalesuser3@test.com", Role = "Sales", RoleId = "cbe2009c-472f-4739-830f-d87368ec6ca4" },
            new UsersRole
            {UserId = "4455d55d-c94a-4565-9926-e45061fdf42e", FirstName = "Test", LastName = "Salesseed", Email = "salesseed@test.com", Role = "Sales", RoleId = "cbe2009c-472f-4739-830f-d87368ec6ca4" },
        };

        public static List<Roles> _Roles = new List<Roles>
        {
            new Roles{Id = "27ca2a56-e86a-476d-91bc-033d438d8ce4", Name = "Admin", Discriminator = "AppRole"},
            new Roles {Id = "cbe2009c-472f-4739-830f-d87368ec6ca4", Name = "Sales", Discriminator = "AppRole" },
            new Roles {Id = "db7b7c24-6300-4d77-8617-0fb3ad71f636", Name = "Disabled", Discriminator = "AppRole"}
        };

        public IEnumerable<Roles> GetAllRoles()
        {
            return _Roles;
        }

        public IEnumerable<SalesUserIdAndName> GetAllSalesUsers()
        {
            List<SalesUserIdAndName> result = new List<SalesUserIdAndName>();

            foreach (var user in _Users)
            {
                SalesUserIdAndName currentRow = new SalesUserIdAndName();
                if(user.Role == "Sales")
                {
                    currentRow.UserId = user.UserId;
                    currentRow.UserName = user.FirstName + " " + user.LastName;
                }

                result.Add(currentRow);
            }
            return result;
        }

        public Roles GetRoleNameForId(string roleId)
        {
            Roles role = _Roles.FirstOrDefault(r => r.Id == roleId);
            return role;
        }

        public UsersRole GetUserById(string userId)
        {
            UsersRole user = _Users.FirstOrDefault(ur => ur.UserId == userId);
            return user;
        }

        public IEnumerable<UsersRole> GetAllUsers()
        {
            return _Users;
        }
    }
}

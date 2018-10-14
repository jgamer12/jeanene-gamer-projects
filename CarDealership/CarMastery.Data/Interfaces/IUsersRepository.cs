using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<UsersRole> GetAllUsers();
        IEnumerable<SalesUserIdAndName> GetAllSalesUsers();
        IEnumerable<Roles> GetAllRoles();
        Roles GetRoleNameForId(string roleId);
        UsersRole GetUserById(string userId);
    }
}

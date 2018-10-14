using CarMastery.Data.ADO;
using CarMastery.Data.Interfaces;
using CarMastery.Data.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Factories
{
    public class UsersRepositoryFactory
    {
        public static IUsersRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new UsersRepositoryADO();
                case "QA":
                    return new UsersRepositorySampleData();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}

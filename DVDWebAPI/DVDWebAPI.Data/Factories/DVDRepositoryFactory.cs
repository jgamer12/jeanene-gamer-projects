using DVDWebAPI.Data.ADO;
using DVDWebAPI.Data.EF;
using DVDWebAPI.Data.Interfaces;
using DVDWebAPI.Data.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data.Factories
{
    public class DVDRepositoryFactory
    {
        public static IDVDRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "EntityFramework":
                    return new DVDRepositoryEF();
                case "ADO":
                    return new DVDRepositoryADO();
                case "SampleData":
                    return new DVDRepositorySampleData();
                default:
                    throw new Exception("Could not find valid Repository Type configuration value.");
            }
        }

    }
}

using CarMastery.Data.ADO;
using CarMastery.Data.Interfaces;
using CarMastery.Data.SampleData;
using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Factories 
{
    public class SalesRepositoryFactory 
    {
        public static ISalesRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new SalesRepositoryADO();
                case "QA":
                    return new SalesRepositorySampleData();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}

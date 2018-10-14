﻿using CarMastery.Data.ADO;
using CarMastery.Data.Interfaces;
using CarMastery.Data.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Factories
{
    public static class VehicleRepositoryFactory
    {
        public static IVehiclesRepository GetRepository()
        {
            switch(Settings.GetRepositoryType())
            {
                case "PROD":
                    return new VehiclesRepositoryADO();
                case "QA":
                    return new VehiclesRepositorySampleData();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}

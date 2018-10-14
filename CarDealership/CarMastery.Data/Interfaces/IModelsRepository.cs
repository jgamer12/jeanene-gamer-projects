using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IModelsRepository
    {
        IEnumerable<MakeModels> GetAllModels();
        IEnumerable<MakeModels> GetModelsForMake(int makeId);
        void AddModel(Models.Tables.Models model);
    }
}

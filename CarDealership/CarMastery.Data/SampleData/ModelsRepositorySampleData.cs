using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class ModelsRepositorySampleData : IModelsRepository
    {
        public static List<Models.Tables.Models> _Models = new List<Models.Tables.Models>
        {
            new Models.Tables.Models
                {ModelId = 1, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Cruze", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 2, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Silverado", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 3, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Tahoe", ModelDateAdded = DateTime.Parse("2018-03-22 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 4, MakeId=1, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Express", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 5, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Fusion", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 6, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "F-150", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 7, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Explorer", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 8, MakeId=2, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Transit Connect", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 9, MakeId=3, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Continental", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 10, MakeId=3, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "MKZ", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
            new Models.Tables.Models
                {ModelId = 11, MakeId=3, UserId="00000000-0000-0000-0000-000000000000", ModelDescription = "Navigator", ModelDateAdded = DateTime.Parse("2018-07-23 00:00:00.0000000")},
        };

        public static List<Makes> _Makes = new List<Makes>
        {
            new Makes
                {MakeId=1, UserId="00000000-0000-0000-0000-000000000000", MakeDescription = "Chevrolet", MakeDateAdded = DateTime.Parse("2018-07-22 00:00:00.0000000")},
            new Makes
                {MakeId=2, UserId="00000000-0000-0000-0000-000000000000", MakeDescription = "Ford", MakeDateAdded = DateTime.Parse("2018-07-22 00:00:00.0000000")},
            new Makes
                {MakeId=3, UserId="00000000-0000-0000-0000-000000000000", MakeDescription = "Lincoln", MakeDateAdded = DateTime.Parse("2018-07-22 00:00:00.0000000")},
        };

        public void AddModel(Models.Tables.Models model)
        {
            model.ModelId = _Models.Max(m => m.ModelId) + 1;
            _Models.Add(model);
        }

        public IEnumerable<MakeModels> GetAllModels()
        {
            List<MakeModels> list = new List<MakeModels>();

            foreach (var model in _Models)
            {
                MakeModels currentRow = new MakeModels();

                currentRow.MakeId = model.MakeId;
                currentRow.MakeDescription = _Makes.FirstOrDefault(m => m.MakeId == model.MakeId).MakeDescription.ToString();
                currentRow.UserName = "placeholder@test.com";
                currentRow.ModelId = model.ModelId;
                currentRow.ModelDescription = model.ModelDescription;
                currentRow.ModelDateAdded = model.ModelDateAdded;

                list.Add(currentRow);
            }
            return list;
        }

        public IEnumerable<MakeModels> GetModelsForMake(int makeId)
        {
            List<MakeModels> list = new List<MakeModels>();

            foreach (var model in _Models)
            {
                MakeModels currentRow = new MakeModels();
                if (makeId == model.MakeId)
                {
                    currentRow.MakeId = model.MakeId;
                    currentRow.MakeDescription = _Makes.FirstOrDefault(m => m.MakeId == model.MakeId).ToString();
                    currentRow.UserName = "placeholder@test.com";
                    currentRow.ModelId = model.ModelId;
                    currentRow.ModelDescription = model.ModelDescription;
                    currentRow.ModelDateAdded = model.ModelDateAdded;

                    list.Add(currentRow);
                }
            }
            return list;
        }

        public void DeleteModel(int modelId)
        {
            _Models.RemoveAll(m => m.ModelId == modelId);
        }
    }
}

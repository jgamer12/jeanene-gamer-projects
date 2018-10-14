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
    public class MakesRepositorySampleData : IMakesRepository
    {
        public static List<Makes> _Makes = new List<Makes>
        {
            new Makes
                {MakeId=1, UserId="00000000-0000-0000-0000-000000000000", MakeDescription = "Chevrolet", MakeDateAdded = DateTime.Parse("2018-07-22 00:00:00.0000000")},
            new Makes
                {MakeId=2, UserId="00000000-0000-0000-0000-000000000000", MakeDescription = "Ford", MakeDateAdded = DateTime.Parse("2018-07-22 00:00:00.0000000")},
            new Makes
                {MakeId=3, UserId="00000000-0000-0000-0000-000000000000", MakeDescription = "Lincoln", MakeDateAdded = DateTime.Parse("2018-07-22 00:00:00.0000000")},
        };

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

        public void AddMake(Makes make)
        {
            make.MakeId = _Makes.Max(m => m.MakeId) + 1;
            _Makes.Add(make);
        }

        public IEnumerable<MakesQuery> GetAllMakes()
        {
            List<MakesQuery> list = new List<MakesQuery>();

            foreach (var make in _Makes)
                {
                MakesQuery currentRow = new MakesQuery();
                currentRow.MakeId = make.MakeId;
                currentRow.UserName = "placeholder@test.com";
                currentRow.MakeDescription = make.MakeDescription;
                currentRow.MakeDateAdded = make.MakeDateAdded;

                list.Add(currentRow);
            }
            return list;
        }

        public void DeleteMake(int makeId)
        {
            _Makes.RemoveAll(m => m.MakeId == makeId);
        }

        public Makes GetMakeForModel(int modelId)
        {
            Makes make = new Makes();

            var result = _Models.FirstOrDefault(m => m.ModelId == modelId);
            make = _Makes.FirstOrDefault(mk => mk.MakeId == result.MakeId);

            return make;
        }
    }
}
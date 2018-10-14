using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class BodyColorsRepositorySampleData : IBodyColorsRepository
    {
        public static List<BodyColors> _BodyColors = new List<BodyColors>
        {
            new BodyColors
                {BodyColorId=1, BodyColorDescription = "Black"},
            new BodyColors
                {BodyColorId=2, BodyColorDescription = "Silver"},
            new BodyColors
                {BodyColorId=3, BodyColorDescription = "Dark Blue"},
            new BodyColors
                {BodyColorId=4, BodyColorDescription = "Red"},
            new BodyColors
                {BodyColorId=5, BodyColorDescription = "White"}
        };
        public List<BodyColors> GetAllBodyColors()
        {
            return _BodyColors;
        }
    }
}

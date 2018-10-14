using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class InteriorColorsRepositorySampleData : IInteriorColorsRepository
    {
        public static List<InteriorColors> _InteriorColors = new List<InteriorColors>
        {
            new InteriorColors
                {InteriorColorId=1, InteriorColorDescription = "Black"},
            new InteriorColors
                {InteriorColorId=2, InteriorColorDescription = "Dark Gray"},
            new InteriorColors
                {InteriorColorId=3, InteriorColorDescription = "Red"},
            new InteriorColors
                {InteriorColorId=4, InteriorColorDescription = "Light Gray"},
            new InteriorColors
                {InteriorColorId=5, InteriorColorDescription = "Tan"}
        };
        public List<InteriorColors> GetAllInteriorColors()
        {
            return _InteriorColors;
        }
    }
}

using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class BodyStylesRepositorySampleData : IBodyStylesRepository
    {
        public static List<BodyStyles> _BodyStyles = new List<BodyStyles>
        {
            new BodyStyles
                {BodyStyleId=1, BodyStyleDescription = "Car"},
            new BodyStyles
                {BodyStyleId=2, BodyStyleDescription = "SUV"},
            new BodyStyles
                {BodyStyleId=3, BodyStyleDescription = "Truck"},
            new BodyStyles
                {BodyStyleId=3, BodyStyleDescription = "Van"}
        };
        public List<BodyStyles> GetAllBodyStyles()
        {
            return _BodyStyles;
        }
    }
}

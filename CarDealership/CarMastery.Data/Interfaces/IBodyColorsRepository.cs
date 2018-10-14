using CarMastery.Models;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IBodyColorsRepository
    {
        List<BodyColors> GetAllBodyColors();
    }
}

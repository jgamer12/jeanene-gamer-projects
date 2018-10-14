using CarMastery.Models;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        IEnumerable<Specials> GetAllSpecials();
        void AddSpecial(Specials special);
        void DeleteSpecial(int specialId);
        Specials GetSpecialById(int SpecialId);
    }
}

using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class SpecialsRepositorySampleData : ISpecialsRepository
    {
        public static List<Specials> _Specials = new List<Specials>
        {
            new Specials
            {SpecialId=1, SpecialTitle= "First Special", SpecialDescription="Special1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem."},
            new Specials
            {SpecialId=2, SpecialTitle= "Second Special", SpecialDescription="Special2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem."},
            new Specials
            { SpecialId=3, SpecialTitle= "Third Special", SpecialDescription="Special3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem."}
        };

        public void AddSpecial(Specials special)
        {
            special.SpecialId = _Specials.Max(s => s.SpecialId) + 1;
            _Specials.Add(special);
        }

        public void DeleteSpecial(int specialId)
        {
            _Specials.RemoveAll(s => s.SpecialId == specialId);
        }

        public IEnumerable<Specials> GetAllSpecials()
        {
            return _Specials;
        }

        public Specials GetSpecialById(int Id)
        {
            Specials special = _Specials.FirstOrDefault(s => s.SpecialId == Id);
            return special;
        }
    }
}
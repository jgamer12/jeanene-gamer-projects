using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class StatesRepositorySampleData : IStatesRepository
    {
        public static List<States> _States = new List<States>
        {
            new States
                {StateId="IA", StateName = "Iowa"},
            new States
                {StateId="IL", StateName = "Illinois"},
            new States
                {StateId="MO", StateName = "Missouri"}
        };
        public List<States> GetAllStates()
        {
            return _States;
        }
    }
}

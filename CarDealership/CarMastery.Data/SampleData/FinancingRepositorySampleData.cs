using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class FinancingRepositorySampleData : IFinancingRepository
    {
        public static List<Financing> _Financing = new List<Financing>
        {
            new Financing
                {FinancingId=1, FinancingDescription = "Bank Finance"},
            new Financing
                {FinancingId=2, FinancingDescription = "Cash"},
            new Financing
                {FinancingId=3, FinancingDescription = "Dealer Finance"}
        };
        public List<Financing> GetAllFinancing()
        {
            return _Financing;
        }
    }
}

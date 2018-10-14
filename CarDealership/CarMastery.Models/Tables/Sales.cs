using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Sales
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int FinancingId { get; set; }
        public string UserId { get; set; }
        public decimal SaleAmount { get; set; }
        public DateTime SaleDate { get; set; }
    }
}

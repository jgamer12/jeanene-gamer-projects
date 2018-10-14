using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class SalesReport
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
        public string TotalSalesFormatted { get; set; } 
    }
}
